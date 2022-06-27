using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_Movement : MonoBehaviour
{

    [Sirenix.OdinInspector.FoldoutGroup("Movement")]
    public float movementForce;

    [Sirenix.OdinInspector.FoldoutGroup("Gravity")]
    public float gravity = 20;


    [Sirenix.OdinInspector.FoldoutGroup("Drag")]
    public float drag = 0.9f;
    [Sirenix.OdinInspector.FoldoutGroup("Drag")]
    public float angularDrag = 0.9f;

    [Sirenix.OdinInspector.FoldoutGroup("Standing")]
    public AnimationCurve standCurve;
    [Sirenix.OdinInspector.FoldoutGroup("Standing")]
    public float standForce;

    Ragdoll ragdoll;

    void Start()
    {
        ragdoll = GetComponentInParent<Ragdoll>();
    }

    void FixedUpdate()
    {
        Gravity();

        if (ragdoll.data.isGrounded)
        {
            Standing();
            Move();
        }

        Drag();

    }

    public void Move()
    {
        for (int i = 0; i < ragdoll.refs.rigs.Length; i++)
        {
            ragdoll.refs.rigs[i].AddForce(ragdoll.data.movementDirection * movementForce, ForceMode.Acceleration);
        }
    }

    void Gravity()
    {
        for (int i = 0; i < ragdoll.refs.rigs.Length; i++)
        {
            ragdoll.refs.rigs[i].AddForce(Vector3.down * ragdoll.data.sinceGrounded * gravity, ForceMode.Acceleration);
        }

    }

    void Drag()
    {
        for (int i = 0; i < ragdoll.refs.rigs.Length; i++)
        {
            ragdoll.refs.rigs[i].velocity *= drag;
            ragdoll.refs.rigs[i].angularVelocity *= angularDrag;
        }
    }

    void Standing()
    {
        ragdoll.refs.head.AddForce(Vector3.up * .2f * standForce * standCurve.Evaluate(ragdoll.data.distanceToGround));
        ragdoll.refs.torso.AddForce(Vector3.up * standForce * standCurve.Evaluate(ragdoll.data.distanceToGround));

    }
}
