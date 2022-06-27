using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_WorldForce : MonoBehaviour
{

    public Vector3 worldForce;
    Rigidbody rig;
    Ragdoll rag;

    void Start()
    {
        rag = GetComponentInParent<Ragdoll>();
        rig = GetComponentInParent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(rag.data.isGrounded)
            rig.AddForce(worldForce, ForceMode.Acceleration);
    }
}
