using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_AI : MonoBehaviour
{

    public Transform targetTransform;
    Ragdoll rag;

    Transform target;
    Walrus walrus;
    public float aggroRange = 15f;

    void Start()
    {
        rag = GetComponent<Ragdoll>();
        walrus = Walrus.Instance;
    }

    void Update()
    {
        if (rag.data.dead)
            return;

        if(target)
        {
            rag.data.target = target;
            return;
        }


        if(Vector3.Distance(transform.position, walrus.transform.position) < aggroRange)
        {
            target = walrus.transform;
        }


        rag.data.targetPosition = targetTransform.position;

        Vector3 moveDir = targetTransform.position - rag.refs.torso.position;
        moveDir.y = 0;
        moveDir = Vector3.ClampMagnitude(moveDir * 0.5f, 1);

        rag.data.movementDirection = moveDir;
    }
}
