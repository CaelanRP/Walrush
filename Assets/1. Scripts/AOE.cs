using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AOEHitData
{
    public Effectable target;
    public Transform transform;
    public Rigidbody rig;
    public Collider col;
    public Vector3 direction;
    public float distance;
    public float distanceEffectMultiplier;
}

public class AOE : MonoBehaviour
{
    [Sirenix.OdinInspector.FoldoutGroup("Effects")]
    public float damage = 50;
    [Sirenix.OdinInspector.FoldoutGroup("Effects")]
    public float knockback = 10;

    public float radius = 5;
    public bool auto = false;
    public bool distanceEffectsPower = true;
    //public bool requireLineOfSight = true;
    [Range(0f, 1f)]
    public float scaling = 1f;

    [HideInInspector]
    public float radiusMultiplier = 1f;

    public bool ignoreOwner = false;

    SpawnedObject spawnedObject;
    //public LayerMask mask;
    void Start()
    {
        radius = Mathf.Lerp(radius, radius * transform.localScale.x, scaling);
        spawnedObject = GetComponentInParent<SpawnedObject>();

        if (auto)
        {
            Go();
        }

    }


    public System.Action<AOEHitData> hitColliderAction;

    [Sirenix.OdinInspector.Button]
    public void Go()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, (radius * radiusMultiplier));
        List<Rigidbody> hitRigs = new List<Rigidbody>();

        for (int i = 0; i < cols.Length; i++)
        {
            if(cols[i].attachedRigidbody)
            {
                if (hitRigs.Contains(cols[i].attachedRigidbody))
                    continue;
                else
                    hitRigs.Add(cols[i].attachedRigidbody);
            }

            
            //if(requireLineOfSight)
                //if (!PhysicsFunctions.CanSee(transform.position, cols[i].transform.position))
                   // continue;

            if(ignoreOwner)
                if(spawnedObject && spawnedObject.spawner)
                {
                    if (cols[i].transform.root.gameObject == spawnedObject.spawner.transform.root.gameObject)
                        continue;
                }



            float distance = Vector3.Distance(transform.position, cols[i].ClosestPoint(transform.position));
            float distanceEffectMultiplier = Mathf.Clamp(1f - (distance / (radius * radiusMultiplier)), 0f, 1f);

            AOEHitData hitData = new AOEHitData();

            hitData.target = cols[i].transform.GetComponentInParent<Effectable>();

            hitData.col = cols[i];
            hitData.rig = cols[i].attachedRigidbody;
            hitData.transform = hitData.rig != null ? hitData.rig.transform : cols[i].transform;
            hitData.distance = distance;

            if (!distanceEffectsPower)
                distanceEffectMultiplier = 1f;
            hitData.distanceEffectMultiplier = distanceEffectMultiplier;

            hitData.direction = (cols[i].transform.position - transform.position).normalized;

            hitColliderAction?.Invoke(hitData);

            if(hitData.target)
            {
                if (damage != 0)
                    hitData.target.TakeDamage(damage);

                if (knockback != 0)
                    hitData.target.AddForce(knockback * distanceEffectMultiplier * (hitData.transform.position - transform.position).normalized);

            }
            

        }
    }


    int team;
    public bool effectTeamMates = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, (Mathf.Lerp(radius, radius * transform.localScale.x, scaling) * radiusMultiplier));
    }
}
