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
   public float initialRushForce;
    float currentRotateForce;
    Rewired.Player _i;

    public enum WALRUSSTATE{
        Waddle,
        Rush
    }

    [ReadOnly]
    public WALRUSSTATE walrusState;
    
    public Rewired.Player input{
        get{
            if (_i == null){
                _i = Rewired.ReInput.players.SystemPlayer; 
            }
            return _i;
        }
    }

    void Update(){
        HandleInput();
    }

    void HandleInput(){
        TestRush();
    }

    void TestRush(){
        if (canRush){
            if (input.GetButtonDown("Rush")){
                Rush();
            }
        }
    }

    void Rush(){
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
            currentRotateForce = Mathf.Max(currentRotateForce - rotateIncreaseRate * Time.fixedDeltaTime, maxRotateSpeed);
        }
        
        rb.AddForce(transform.forward * currentWalkVector.magnitude * waddleSpeed);
        //rb.AddForce(new Vector2)
    }

    void ApplyWalkTorque(){
        float angle = Vector3.SignedAngle(transform.forward, cameraRelativeMoveVector, Vector3.up);
        float unsignedAngle = Mathf.Abs(angle);

        if (unsignedAngle > 5){

            currentRotateForce = Mathf.Min(currentRotateForce + rotateIncreaseRate * Time.fixedDeltaTime, maxRotateSpeed);
            rb.AddTorque(Vector3.up * Mathf.Sign(angle) * currentRotateForce);
        }

        rb.angularDrag = Mathf.Lerp(maxAngularDrag, minAngularDrag, unsignedAngle / 180);
    }
}
