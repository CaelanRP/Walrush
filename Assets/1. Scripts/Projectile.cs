using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public UnityEngine.Events.UnityEvent hitEvent;

    public Vector3 localForce;

    public Vector3 worldForce;


    public float gravity = 20;

    public bool destroyOnHit = true;

    internal Vector3 velocity;

    Vector3 lastpos;

    List<Transform> ignoredRoots = new List<Transform>();

    [Sirenix.OdinInspector.FoldoutGroup("Stats")]
    public int bounces = 0;

    [Sirenix.OdinInspector.FoldoutGroup("Stats")]
    public float damage = 0;

    [Sirenix.OdinInspector.FoldoutGroup("Stats")]
    public float knockback = 0;

    LayerMask mask;

    SpawnedObject spawnedObject;
    int team = 0;

    void Start()
    {

        mask = LayerMask.GetMask(new string[] {"Default", "Map", "Terrain"});

        velocity += worldForce;

        velocity += transform.TransformDirection(localForce);

        lastpos = transform.position;

        spawnedObject = GetComponent<SpawnedObject>();

    }

    internal float distanceTravelled;

    void Update()
    {
        if (done)
            return;

        Move();

        CheckForCollision();

        distanceTravelled += Vector3.Distance(transform.position, lastpos);

        lastpos = transform.position;
    }


    void Move()
    {
        transform.position += velocity * Time.deltaTime;

        velocity += gravity * Time.deltaTime * Vector3.down;
        velocity -= velocity * drag * Time.deltaTime;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * 5);
    }


    void CheckForCollision()
    {
        Ray ray = new Ray(lastpos, transform.position - lastpos);

        RaycastHit[] hits = Physics.RaycastAll(ray, Vector3.Distance(transform.position, lastpos), mask); //Physics.SphereCastAll(ray, 0.5f, Vector3.Distance(transform.position, lastpos)); //Physics.RaycastAll(ray, Vector3.Distance(transform.position, lastpos));
        RaycastHit hit = new RaycastHit();
        CheckHits();

        void CheckHits()
        {
            for (int i = 0; i < hits.Length; i++)
            {
                if (ignoredRoots.Contains(hits[i].transform.root))
                    continue;

                if (hits[i].point == Vector3.zero)
                    continue;

                Effectable targ = hits[i].transform.GetComponent<Effectable>();


                if (hit.transform == null || hits[i].distance < hit.distance)
                    hit = hits[i];
            }
        }

        if (hit.transform)
        {
            ProcessHit(hit);
        }
    }

    public void IgonreRootFor(Transform root, float seconds)
    {
        StartCoroutine(IIgnoreRootsFor(root, seconds));

        IEnumerator IIgnoreRootsFor(Transform root, float seconds)
        {
            ignoredRoots.Add(root);
            yield return new WaitForSeconds(seconds);
            ignoredRoots.Remove(root);
        }
    }


    public System.Action<RaycastHit> hitAction;

    void ProcessHit(RaycastHit hit)
    {
        Effectable target = hit.transform.GetComponentInParent<Effectable>();

        Effects(hit, target);

        if (bounces > 0)
        {
            transform.position = hit.point + hit.normal * 0.1f;

            velocity = Vector3.Reflect(velocity, hit.normal);

            float mag = velocity.magnitude;
            mag = Mathf.Lerp(mag, 40, 0.75f);
            velocity = velocity.normalized * mag;

            gravity = Mathf.Lerp(gravity, 60, 0.75f);
            bounces--;

            GetComponent<RemoveAfterSeconds>().seconds = 5f;

            return;
        }

        End(hit);
    }

   


    void Effects(RaycastHit hit, Effectable target)
    {
        if(target)
        {
            target.TakeDamage(damage);
            target.AddForce(knockback * transform.forward);
        }

        hitAction?.Invoke(hit);
        //playerSpawner.ProjectileHit(hit, this, onlyEnchantmentEffects);

    }

    public System.Action<RaycastHit> dieAction;


    bool done = false;
    internal bool healFriends = false;
    internal float drag = 0f;

    void End(RaycastHit hit)
    {

        hitEvent.Invoke();
        dieAction?.Invoke(hit);
        done = true;

        if (destroyOnHit)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            StartCoroutine(IDestroy());

            IEnumerator IDestroy()
            {
                yield return new WaitForSeconds(30f);
                Destroy(gameObject);
            }
        }
        else
            this.enabled = false;
    }


    internal float DamageMultiplier()
    {
        return damage / 51;
    }
}

public class ProjectileHitData
{
    public Vector3 point;
    public Vector3 normal;
    public Transform transf;
    public Collider collider;
    public Rigidbody rig;
    public Effectable player;
    public GameObject owner;
    public int hitViewID;
    public Transform ownProjectile;

    public ProjectileHitData(Vector3 hitPoint, Vector3 hitNormal, Transform hitTransform, Collider hitCollider, Rigidbody hitRig,
        Effectable hitPlayer, GameObject owner, int hitViewID, Transform ownProjectile)
    {
        this.point = hitPoint;
        this.normal = hitNormal;
        this.transf = hitTransform;
        this.collider = hitCollider;
        this.rig = hitRig;
        this.player = hitPlayer;
        this.owner = owner;
        this.hitViewID = hitViewID;
        this.ownProjectile = ownProjectile;
    }
}