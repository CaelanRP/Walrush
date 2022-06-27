﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RotationSpringInstance
{
    public bool useTimeScale = true;
    public float spring = 15, damper = 15;

    Vector3 targetForward, targetUp;
    Vector3 vel;

    public void DoStart(Transform transform)
    {
        targetForward = transform.parent.InverseTransformDirection(transform.forward);
        targetUp = transform.parent.InverseTransformDirection(transform.up);
    }

    public void DoUpdate(Transform transform)
    {
        Vector3 worldForward = directionsRelativeToParent ? transform.parent.TransformDirection(targetForward) : targetForward;
        Vector3 worldUp = directionsRelativeToParent ? transform.parent.TransformDirection(targetUp) : targetUp;

        Vector3 forwardDelta = Vector3.Cross(transform.forward, worldForward).normalized * Vector3.Angle(transform.forward, worldForward);
        Vector3 upDelta = Vector3.Cross(transform.up, worldUp).normalized * Vector3.Angle(transform.up, worldUp);

        vel = FRILerp.Lerp(vel, (forwardDelta + upDelta) * spring, damper);

        transform.Rotate(vel * Time.deltaTime, Space.World);
    }


    internal bool directionsRelativeToParent = true;
    internal void SetDirections(Vector3 targetForward, Vector3 targetUp)
    {
        this.targetForward = targetForward;
        this.targetUp = targetUp;
    }

    public void DoOnDestroy(Transform transform)
    {
        Vector3 worldForward = transform.parent.TransformDirection(targetForward);
        Vector3 worldUp = transform.parent.TransformDirection(targetUp);

        transform.rotation = Quaternion.LookRotation(worldForward, worldUp);
    }

    internal void AddForce(Vector3 force)
    {
        vel += force;
    }


    internal void AddForce_World(Transform transform, Vector3 force, Vector3 pos, float range = 0)
    {
        float m = 1f;

        if (range != 0)
        {
            float dist = Vector3.Distance(pos, transform.position);

            if (dist > range)
                return;

            m = Mathf.Clamp((1f - (dist / range)), 0f, 1f);
        }

        Vector3 toObj = transform.position - pos;
        force = Vector3.Cross(toObj, force).normalized * force.magnitude;

        vel += -force * m;
    }

    internal void AddForce_WorldCamera(Vector3 force, Vector3 pos, float range = 0)
    {
        float m = 1f;

        if (range != 0)
        {
            float dist = Vector3.Distance(pos, Camera.main.transform.position);

            if (dist > range)
                return;

            m = Mathf.Clamp((1f - (dist / range)), 0f, 1f);
        }

        Vector3 toCam = Camera.main.transform.position - pos;
        force = Vector3.Cross(toCam, force).normalized * force.magnitude;


        force = Camera.main.transform.InverseTransformDirection(force);

        vel += force * m;
    }

}

public class RotationSpring : MonoBehaviour
{
    public RotationSpringInstance rotationSpringInstance;


    void Start()
    {
        rotationSpringInstance.DoStart(transform);
    }

    void Update()
    {
        rotationSpringInstance.DoUpdate(transform);

    }

    private void OnDestroy()
    {
        if(rotationSpringInstance != null && transform) 
            rotationSpringInstance.DoOnDestroy(transform);
    }

    internal void AddForce(Vector3 force)
    {
        rotationSpringInstance.AddForce(force);
    }


    internal void AddForce_World(Vector3 force, Vector3 pos, float range = 0)
    {
        rotationSpringInstance.AddForce_World(transform, force, pos, range);
    }

    internal void AddForce_WorldCamera(Vector3 force, Vector3 pos, float range = 0)
    {
        rotationSpringInstance.AddForce_WorldCamera(force, pos, range);
    }
}