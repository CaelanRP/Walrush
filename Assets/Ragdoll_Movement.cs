using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_Movement : MonoBehaviour
{

    [Sirenix.OdinInspector.FoldoutGroup("Movement")]
    public float movementForce;
    [Sirenix.OdinInspector.FoldoutGroup("Movement")]
    public float rotationForce;

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
        if (ragdoll.data.dead)
            return;


        Gravity();

        if (ragdoll.data.isGrounded)
        {
            Standing();
        }

        Move();
        Drag();

    }


    public void Move()
    {
        /*
        Vector3 forw = ragdoll.refs.torso.transform.forward;
        forw.y = 0;
        Vector3 delta = Vector3.Cross(forw, ragdoll.data.movementDirection).normalized * Vector3.Angle(forw, ragdoll.data.movementDirection);
        ragdoll.refs.torso.AddTorque(delta * rotationForce, ForceMode.Acceleration);
        ragdoll.refs.hip.AddTorque(delta * rotationForce, ForceMode.Acceleration);
        */
        if(ragdoll.data.target)
        {
            ragdoll.refs.anim.transform.rotation = Quaternion.Lerp(ragdoll.refs.anim.transform.rotation, Quaternion.LookRotation(ragdoll.data.target.position - transform.position), Time.fixedDeltaTime * 25f);

        }
        else if(ragdoll.data.movementDirection.magnitude > 0.2f)
            ragdoll.refs.anim.transform.rotation = Quaternion.Lerp(ragdoll.refs.anim.transform.rotation, Quaternion.LookRotation(ragdoll.data.movementDirection), Time.fixedDeltaTime * 25f);


        if (ragdoll.data.target)
        {

        }
        else
        {
            for (int i = 0; i < ragdoll.refs.rigs.Length; i++)
            {
                ragdoll.refs.rigs[i].AddForce(ragdoll.data.movementDirection * movementForce, ForceMode.Acceleration);

            }
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
