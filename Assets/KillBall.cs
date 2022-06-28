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

        Vector3 forceDir = (other.transform.position - transform.position);
        effectable.AddForce(forceDir.normalized * force);

        if (effectable is Effectable_Ragdoll)
        {
            if (!effectable.GetComponent<Ragdoll>().data.dead)
            {
                ParticleManager.instance.SpawnHit(other.ClosestPoint(transform.position), forceDir);
            }
        }

        effectable.TakeDamage(dmg);
    }//

}
