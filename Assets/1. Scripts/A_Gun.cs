using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Gun : MonoBehaviour
{

    public GameObject projectileToSpawn;


    int currentAmmo;

    public Action<Projectile> FireBulletAction { get; internal set; }

    void Start()
    {
    }

    public void DoAttack()
    {

        Fire();

        void Fire()
        {

            Transform target = GetComponentInParent<Ragdoll>().data.target.transform;
            GameObject spawned = Instantiate(projectileToSpawn, transform.position, Quaternion.LookRotation(transform.forward));

            spawned.transform.Rotate(UnityEngine.Random.insideUnitSphere);

            SpawnedObject.ConfigureNewObject(spawned, transform.root.gameObject);

            Projectile proj = spawned.GetComponent<Projectile>();

            FireBulletAction?.Invoke(proj);
        }
        
        

    }

}
