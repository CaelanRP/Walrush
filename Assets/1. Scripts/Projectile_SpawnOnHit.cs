using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_SpawnOnHit : MonoBehaviour
{

    public GameObject objectToSpawn;

    void Start()
    {
        GetComponent<Projectile>().hitAction += Hit;
    }

    private void Hit(RaycastHit obj)
    {
        GameObject spawned = Instantiate(objectToSpawn, obj.point, Quaternion.LookRotation(obj.normal));
        SpawnedObject.ConfigureNewObject(spawned, gameObject);
    }
}
