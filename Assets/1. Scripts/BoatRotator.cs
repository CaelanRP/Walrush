using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoatRotator : MonoBehaviour
{
    public RotationSpring rotation;
    public PositionSpring position;
    public float boatSizeX, boatSizeZ;
    public float slidyForceMultiplier;

    [HideInInspector]
    public Vector3 currentSlidyVector;
    // Start is called before the first frame update
    public void Slam(float rotationAmt, float positionAmt, Vector3 position){
        rotation.AddForce_World(Vector3.up * rotationAmt, position, boatSizeX, boatSizeZ);
        this.position.AddForce(Vector3.up * positionAmt, position, boatSizeX * 2, boatSizeZ * 2);

        TriggerBoatDipped(positionAmt, position);
    }
    
    private static BoatRotator _I;
    public static BoatRotator Instance{
        get{
            if (!_I){
                _I = FindObjectOfType<BoatRotator>();
            }
            return _I;
        }
    }

    void OnEnable(){
        if (_I != null && _I != this)
        {
            Destroy(this);
            return;
        }
        _I = this;
    }

    void FixedUpdate(){
        UpdateSlidyForce();
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

    void UpdateSlidyForce(){
        currentSlidyVector = ((Vector3.down) - (-transform.up)) * slidyForceMultiplier;
    }
}
