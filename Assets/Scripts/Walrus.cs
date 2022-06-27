using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using Sirenix.OdinInspector;

public class Walrus : Entity
{
    [BoxGroup("Movement Physics")][TitleGroup("Movement Physics/Waddle")]
    public float waddleSpeed;
    [TitleGroup("Movement Physics/Waddle")]
    public float minRotateSpeed, maxRotateSpeed, rotateIncreaseRate, minAngularDrag, maxAngularDrag;

   [TitleGroup("Movement Physics/Rush")]
   public float initialRushForce, XZDragRush, minRotateSpeedRush, maxRotateSpeedRush, rotateIncreaseRateRush, minAngularDragRush, maxAngularDragRush;
    float currentRotateForce;

    public float currentMinRotateSpeed{ get{ return rushing ? minRotateSpeedRush : minRotateSpeed; } }

    public float currentMaxRotateSpeed{ get{ return rushing ? maxRotateSpeedRush : maxRotateSpeed; } }

    public float currentRotateIncreaseRate{ get{ return rushing ? rotateIncreaseRateRush : rotateIncreaseRate; } }

    public float currentMinAngularDrag{ get{ return rushing ? minAngularDragRush : minAngularDrag; } }
    public float currentMaxAngularDrag{ get{ return rushing ? maxAngularDragRush : maxAngularDrag; } }

    Rewired.Player _i;

    bool rushing;
    
    public Rewired.Player input{
        get{
            if (_i == null){
                _i = Rewired.ReInput.players.SystemPlayer; 
            }
            return _i;
        }
    }

    public override float XZDrag{
        get{
            return rushing ? XZDragRush : defaultXZDrag;
        }
    }

    void Update(){
        HandleInput();
    }

    void HandleInput(){
        TestRush();
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

    void StartRush(){
        rushing = true;
        rb.AddForce(transform.forward * initialRushForce, ForceMode.Impulse);
    }

    bool canRush{
        get{
            return true;
        }
    }


    protected override void FixedUpdate(){
        base.FixedUpdate();
        HandleInputFixed();
    }

    Vector2 currentWalkVector;
    Vector3 cameraRelativeMoveVector;
    void HandleInputFixed(){
        currentWalkVector = input.GetAxis2D("MoveX", "MoveY");
        
        cameraRelativeMoveVector = CameraController.Instance.transform.TransformVector(new Vector3(currentWalkVector.x, 0, currentWalkVector.y));

        if (currentWalkVector.magnitude > 0.1f){
            ApplyWalkTorque();
        }

        else{
            currentRotateForce = Mathf.Max(currentRotateForce - currentRotateIncreaseRate * Time.fixedDeltaTime, currentMinRotateSpeed);
        }
        
        if (rushing){
            rb.velocity = Vector3.RotateTowards(rb.velocity, transform.forward, Mathf.Infinity, 0);
        }
        else{
            rb.AddForce(transform.forward * currentWalkVector.magnitude * waddleSpeed);
        }
        //rb.AddForce(new Vector2)
    }

    void ApplyWalkTorque(){
        float angle = Vector3.SignedAngle(transform.forward, cameraRelativeMoveVector, Vector3.up);
        float unsignedAngle = Mathf.Abs(angle);

        if (unsignedAngle > 5){

            currentRotateForce = Mathf.Min(currentRotateForce + currentRotateIncreaseRate * Time.fixedDeltaTime, currentMaxRotateSpeed);
            rb.AddTorque(Vector3.up * Mathf.Sign(angle) * currentRotateForce);
        }

        rb.angularDrag = Mathf.Lerp(currentMaxAngularDrag, currentMinAngularDrag, unsignedAngle / 180);
    }
}
