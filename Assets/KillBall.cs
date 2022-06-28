using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBall : MonoBehaviour
{
    public float force;
    public float dmg = 101;

    private void OnTriggerEnter(Collider other)
    {
        Effectable effectable = other.GetComponentInParent<Effectable>();

        if (!effectable)
            return;

        effectable.AddForce((other.transform.position - transform.position).normalized * force);
        effectable.TakeDamage(dmg);

        

    }//

}
