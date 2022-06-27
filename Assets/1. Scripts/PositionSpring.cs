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
        vel += force;
    }
}
