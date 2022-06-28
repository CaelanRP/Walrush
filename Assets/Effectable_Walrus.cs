using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effectable_Walrus : Effectable
{

    Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();

    }

    public override void AddForce(Vector3 force)
    {
        rig.AddForce(force * 10, ForceMode.Impulse);
    }

    public override void TakeDamage(float damage, Vector3 dir)
    {
        Gamefeel.instance.EnableObjects("DMG", .1f);
        Gamefeel.instance.AddRotationShake_World(dir * damage * 2f, transform.position);
        Gamefeel.instance.AddTremble(.3f, .15f);
    }

}
