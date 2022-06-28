using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSpring : MonoBehaviour
{
    public bool useTimeScale = true;
    public float spring = 15, damper = 15;

    Vector3 targetPos;
    Vector3 vel;

    void Start()
    {
        targetPos = transform.localPosition;
    }

    void Update()
    {

        Vector3 worldPos = transform.parent.TransformDirection(targetPos);

        Vector3 delta = worldPos - transform.position;

        vel = FRILerp.Lerp(vel, (delta) * spring, damper);

        transform.position += (vel * Time.deltaTime);
    }

    internal void AddForce(Vector3 force)
    {
        vel += force * m;
    }

    internal void AddForce(Vector3 force, Vector3 pos, float range = 0)
    {
        float m = 1f;

        if (range != 0)
        {
            float dist = Vector3.Distance(pos, transform.position);

            if (dist > range)
                return;

            m = Mathf.Clamp((1f - (dist / range)), 0f, 1f);
        }

        vel += force * m;
    }
}
