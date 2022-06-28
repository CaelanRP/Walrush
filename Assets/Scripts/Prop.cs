using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Entity
{
    void OnEnable(){
        BoatRotator.Instance.OnBoatDipped += TestBoatDipped;
    }

    void OnDisable(){
        if (BoatRotator.Instance){
            BoatRotator.Instance.OnBoatDipped -= TestBoatDipped;
        }
    }

    void TestBoatDipped(float amount, Vector3 position){
        Debug.Log("DIPPING");
        float ratio = Vector3.Distance(position, transform.position) / 10f;
        ratio = Mathf.Clamp(ratio, 0,1);
        rb.velocity = rb.velocity + ((-CameraController.Instance.currentDown *5) * (1-ratio));
    }

    protected override void FixedUpdate(){
        base.FixedUpdate();
        rb.AddForce(BoatRotator.Instance.currentSlidyVector * Time.fixedDeltaTime);
    }
}
