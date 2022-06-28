using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoatRotator : MonoBehaviour
{
    public RotationSpring rotation;
    public PositionSpring position;
    public float boatDipRange = 20;
    // Start is called before the first frame update
    public void Slam(float rotationAmt, float positionAmt, Vector3 position){
        rotation.AddForce_World(Vector3.up * rotationAmt, position);
        this.position.AddForce(Vector3.up * positionAmt, position, boatDipRange);
    }
    
    public static BoatRotator Instance;

    void OnEnable(){
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }


    public delegate void BoatDippedDel(float amount, Vector3 position);
    public event BoatDippedDel OnBoatDipped;

    // When an entity hits another entity
    public void TriggerBoatDipped(float amount, Vector3 position){
        
        if (OnBoatDipped != null){
            try{
                OnBoatDipped(amount, position);
            } catch(Exception ex){
                Debug.LogError(ex);
            }
        }
    }
}
