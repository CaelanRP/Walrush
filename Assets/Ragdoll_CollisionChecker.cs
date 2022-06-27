using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_CollisionChecker : MonoBehaviour
{

    Ragdoll ragdoll;

    void Start()
    {
        ragdoll = GetComponentInParent<Ragdoll>();
    }

    void OnCollisionEnter(Collision col)
    {
        Collide(col);

    }
    void OnCollisionStay(Collision col)
    {
        Collide(col);
    }

    private void Collide(Collision col)
    {
        ragdoll.data.Collide(col);
    }

}
