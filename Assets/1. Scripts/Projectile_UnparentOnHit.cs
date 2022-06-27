using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_UnparentOnHit : MonoBehaviour
{
    void Start()
    {
        GetComponentInParent<Projectile>().dieAction += Die;
    }

    private void Die(RaycastHit obj)
    {
        gameObject.AddComponent<RemoveAfterSeconds>();
        transform.SetParent(null, true);
    }

}
