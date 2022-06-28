using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effectable_Breakable : Effectable
{

    public GameObject[] brokenVersion;
    public float health = 100;

    Rigidbody rig;

    Vector3 forceAdded;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    public override void TakeDamage(float damage, Vector3 dir)
    {
        health -= damage;

        if (health < 0)
            Die();
    }


    private void Update()
    {
        forceAdded = Vector3.Lerp(forceAdded, Vector3.zero, Time.deltaTime * 5);
    }

    bool dead = false;
    private void Die()
    {
        if (dead)
            return;

        dead = true;
        GameObject spawned = Instantiate(brokenVersion[UnityEngine.Random.Range(0, brokenVersion.Length)], transform.position, transform.rotation);
        Destroy(gameObject);

        Rigidbody[] rigs = spawned.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigs.Length; i++)
        {
            rigs[i].AddForce(forceAdded * .3f, ForceMode.Impulse);
        }

        Gamefeel.instance.AddTremble(0.05f, 0.1f);
        Gamefeel.instance.AddRotationShake_World((forceAdded).normalized * 30, transform.position);

    }

    public override void AddForce(Vector3 force)
    {
        if (dead)
            return;

        forceAdded += force;

        rig.AddForce(force, ForceMode.Impulse);
    }
}
