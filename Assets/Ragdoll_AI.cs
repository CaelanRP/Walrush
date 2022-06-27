using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_AI : MonoBehaviour
{

    public Transform targetTransform;
    Ragdoll rag;

    void Start()
    {
        rag = GetComponent<Ragdoll>();
    }

    void Update()
    {
        rag.data.target = targetTransform;
        rag.data.targetPosition = targetTransform.position;

        Vector3 moveDir = targetTransform.position - rag.refs.torso.position;
        moveDir.y = 0;
        moveDir = moveDir.normalized;

        rag.data.movementDirection = moveDir;
    }
}
