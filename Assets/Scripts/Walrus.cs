using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Sirenix.OdinInspector;

public class Walrus : Entity
{
    [BoxGroup("Movement Physics")][TitleGroup("Movement Physics/Waddle")]
    public float waddleSpeed, waddleStepSpeed;
    [TitleGroup("Movement Physics/Waddle")]
    public float minRotateSpeed, maxRotateSpeed, rotateIncreaseRate, minAngularDrag, maxAngularDrag;

   [TitleGroup("Movement Physics/Rush")]
   public float initialRushForce, rushAdjustForce, XZDragRush, minRotateSpeedRush, maxRotateSpeedRush, rotateIncreaseRateRush, minAngularDragRush, maxAngularDragRush, rushRotationControlVelocityCap;
    [TitleGroup("Movement Physics/Bounce")]
    public float minBounceVelocity;
    [BoxGroup("Additional Stats")][TitleGroup("Additional Stats/Boat Dip")]
    public float goreSlamBoatDip, goreSlamBoatTip, rushBoatDip, rushBoatTip;
    float currentRotateForce;

    public float currentMinRotateSpeed{ get{ return rushing ? minRotateSpeedRush : minRotateSpeed; } }

    public float currentMaxRotateSpeed{ get{ return rushing ? maxRotateSpeedRush : maxRotateSpeed; } }

    public float currentRotateIncreaseRate{ get{ return rushing ? rotateIncreaseRateRush : rotateIncreaseRate; } }

    public float currentMinAngularDrag{ get{ return rushing ? minAngularDragRush : minAngularDrag; } }
    public float currentMaxAngularDrag{ get{ return rushing ? maxAngularDragRush : maxAngularDrag; } }

    Rewired.Player _i;

    bool rushing;


    [TitleGroup("VFX")]
    public ParticleSystem[] vfx;

    public Rewired.Player input{
        get{
            if (_i == null){
                _i = Rewired.ReInput.players.GetPlayer(0); 
            }
            return _i;
        }
    }

    float currentDrag;
    public override float XZDrag{
        get{
            return currentDrag;
        }
    }

    public static Walrus Instance;

    Animator animator;

    void OnEnable(){
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    void Start(){
        animator = GetComponentInChildren<Animator>();
    }

    void Update(){
        HandleInput();
        UpdateAnimationValues();

        vfx[0].transform.forward = -(new Vector3(rb.velocity.x, 0 , rb.velocity.z));
    }

    void HandleInput(){
        TestRush();
        TestGore();
    }

    
    void TestRush(){
        if (rushing){
            if (!input.GetButton("Rush")){
                rushing = false;
            }
        }
        else {
            if (canRush){
                if (input.GetButtonDown("Rush")){
                    StartRush();
                }
            }
        }
    }

    void TestGore(){
        if (input.GetButtonDown("Gore")){
            Gore();
        }
    }

    void Gore(){
        BoatRotator.Instance.Slam(goreSlamBoatTip, goreSlamBoatDip, transform.position);
        Gamefeel.instance.AddTremble(20, 0.5f);
    }

    void StartRush(){
        rushing = true;
        rb.AddForce(transform.forward * initialRushForce, ForceMode.Impulse);
        BoatRotator.Instance.Slam(rushBoatTip, rushBoatDip, transform.position);
        vfx[0].Play();

        Gamefeel.instance.AddTremble(2, 0.5f);

        UpdateDragValue();
    }

    bool canRush{
        get{
            return true;
        }
    }

    Vector3 previousVelocity;
    protected override void FixedUpdate(){
        base.FixedUpdate();
        HandleInputFixed();

        UpdateDragValue();

        previousVelocity = rb.velocity;
        //Debug.Log(rb.velocity.magnitude);

        if (transform.eulerAngles.z != 0){
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
    }

    Vector2 currentWalkVector;
    Vector3 cameraRelativeMoveVector;
    void HandleInputFixed(){
        currentWalkVector = input.GetAxis2D("MoveX", "MoveY");
        
        cameraRelativeMoveVector = CameraController.Instance.transform.TransformVector(new Vector3(currentWalkVector.x, 0, currentWalkVector.y));

        animator.SetFloat("xJoystick", currentWalkVector.x, 0.25f, Time.fixedDeltaTime);

        if (Time.time - lastBounced > 0.1f){
            if (currentWalkVector.magnitude > 0.1f){
                ApplyWalkTorque();
                
            }

            else{
                currentRotateForce = Mathf.Max(currentRotateForce - currentRotateIncreaseRate * Time.fixedDeltaTime, currentMinRotateSpeed);
                animator.SetFloat("walking", 0, 0.5f, Time.fixedDeltaTime);
            }
            
            if (rushing){
                float rushForce = rushAdjustForce * Mathf.Lerp(0, 1, rb.velocity.magnitude / rushRotationControlVelocityCap);
                rb.AddForce(cameraRelativeMoveVector * rushForce * Time.fixedDeltaTime);
                //rb.velocity = Vector3.Lerp(rb.velocity, transform.forward * rb.velocity.magnitude, rushForceLerp * Time.fixedDeltaTime);
            }
            else{
                rb.AddForce(transform.forward * currentWalkVector.magnitude * waddleSpeed);
            }
        }
        //rb.AddForce(new Vector2)
    }

    public void Step(){
        if (!rushing)
        {
            rb.AddForce(transform.forward * currentWalkVector.magnitude * waddleStepSpeed * animator.GetFloat("walking"), ForceMode.Impulse);
        }
    }

    void ApplyWalkTorque(){
        float angle = Vector3.SignedAngle(transform.forward, cameraRelativeMoveVector, Vector3.up);
        float unsignedAngle = Mathf.Abs(angle);

        if (unsignedAngle > 5){

            currentRotateForce = Mathf.Min(currentRotateForce + currentRotateIncreaseRate * Time.fixedDeltaTime, currentMaxRotateSpeed);
            if (rushing){
                //float rotateForceMultiplier = Mathf.Lerp(0, 1, rb.velocity.magnitude / rushRotationControlVelocityCap);
                //currentRotateForce *= rotateForceMultiplier;
            }
            rb.AddTorque(Vector3.up * Mathf.Sign(angle) * currentRotateForce);
            animator.SetFloat("walking", 1, 1, Time.fixedDeltaTime);
        }
        else{
            animator.SetFloat("walking", 1, 1, Time.fixedDeltaTime);
        }
        rb.angularDrag = Mathf.Lerp(currentMaxAngularDrag, currentMinAngularDrag, unsignedAngle / 180);
    }

    float lastBounced;
    void OnCollisionEnter(Collision coll){
        if (coll.gameObject.tag == "Wall"){
            Vector3 vel = Util.ZeroY(Vector3.Reflect(previousVelocity, coll.GetContact(0).normal));
            rb.velocity = vel;
            if (rushing){
                //transform.forward = Util.ZeroY(vel);
                lastBounced = Time.time;
                //StartCoroutine(SetVelocityAndRotationNextFrame(vel));
                //rb.angularVelocity = Vector3.zero;
            }
        }
    }

    IEnumerator SetVelocityAndRotationNextFrame(Vector3 velocity){
        yield return new WaitForFixedUpdate();
        rb.velocity = velocity;
        transform.forward = Util.ZeroY(velocity);
        rb.angularVelocity = Vector3.zero;
    }

    void UpdateGrounded(){
        
    }

    protected void UpdateDragValue()
    {
        if (rushing)
        {
            currentDrag = XZDragRush;
        }
        else
        {
            currentDrag = Mathf.MoveTowards(currentDrag, defaultXZDrag, 5000 * Time.fixedDeltaTime);
        }
    }

    void UpdateAnimationValues(){
        animator.SetFloat("forwardVelocity", rb.velocity.magnitude);
        animator.SetFloat("rotationalVelocity", rb.angularVelocity.magnitude);   
    }
}
