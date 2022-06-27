using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRotator : MonoBehaviour
{
    public RotationSpring rotation;
    public PositionSpring position;
    // Start is called before the first frame update
    public void Slam(float rotationAmt, float positionAmt, Vector3 position){
        rotation.AddForce_World(Vector3.up * rotationAmt, position);
        this.position.AddForce(Vector3.up * positionAmt);
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
}
