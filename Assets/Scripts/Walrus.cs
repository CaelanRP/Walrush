using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Walrus : Entity
{
    public float waddleSpeed;
    public float minRotateSpeed, maxRotateSpeed, rotateIncreaseRate, minAngularDrag, maxAngularDrag;
    float currentRotateForce;
    Rewired.Player _i;
    
    public Rewired.Player input{
        get{
            if (_i == null){
                _i = Rewired.ReInput.players.SystemPlayer; 
            }
            return _i;
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

        rb.AddForce(cameraRelativeMoveVector * waddleSpeed);

        if (currentWalkVector.magnitude > 0.1f){
            ApplyWalkTorque();
        }
        else{
            currentRotateForce = Mathf.Max(currentRotateForce - rotateIncreaseRate * Time.fixedDeltaTime, maxRotateSpeed);
        }
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
