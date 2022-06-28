using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effectable_Ragdoll : Effectable
{

    Ragdoll ragdoll;

    private void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(101);
            AddForce(UnityEngine.Random.onUnitSphere * 1000);
        }
    }


    public override void AddForce(Vector3 force)
    {
        ragdoll.refs.torso.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    public override void TakeDamage(float damage)
    {
        ragdoll.data.currentHp -= damage;

        if(ragdoll.data.currentHp <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        if (ragdoll.data.dead)
            return;

        ragdoll.data.dead = true;

        Gamefeel.instance.AddTremble(0.2f, 0.2f);
        Gamefeel.instance.AddRotationShake_World((ragdoll.refs.torso.GetComponent<Rigidbody>().velocity).normalized * 25, transform.position);
    }
}
