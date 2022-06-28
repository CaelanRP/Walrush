using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_AnimationHandler : MonoBehaviour
{

    Animator animator;
    Ragdoll rag;

    void Start()
    {
        rag = GetComponent<Ragdoll>();
        animator = GetComponentInChildren<Animator>();

        MeshRenderer[] rends = animator.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].enabled = false;
        }

    }

    void Update()
    {

        Vector3 vel = rag.refs.torso.velocity;
        vel.y = 0;
        animator.SetFloat("Speed", vel.magnitude, .2f, Time.deltaTime);
        animator.SetBool("Aggro", rag.data.target != null && !rag.data.dead);
    }
}
