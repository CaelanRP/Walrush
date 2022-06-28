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

    internal void AddForce(Vector3 force, Vector3 pos, float rangeX, float rangeZ)
    {
        float m = 1f;

        float xDistRatio = Mathf.Abs(pos.x - transform.position.x) / rangeX;
        float zDistRatio = Mathf.Abs(pos.z - transform.position.z) / rangeZ;
        Debug.Log("x ratio: " + xDistRatio + " z ratio: " + zDistRatio);
        float ratio = Mathf.Max(xDistRatio, zDistRatio); // Choose the higher ratio distance, effectively lowering dip if we are far from the center on either axis

            float dist = Vector3.Distance(pos, transform.position);

            m = Mathf.Clamp((1f - ratio), 0f, 1f);

        vel += force * m;
    }
}
