using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Walrus : Entity
{
    public float waddleSpeed;
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
        
        cameraRelativeMoveVector = CameraController.Instance.transform.TransformVector(currentWalkVector);

        rb.AddForce(cameraRelativeMoveVector * waddleSpeed);
        //currentMoveForce = new Vector3()


        //rb.AddForce(new Vector2)
    }
}
