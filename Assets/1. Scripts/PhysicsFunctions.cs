using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsFunctions
{


    public static LayerMask mapAndTerrain = LayerMask.GetMask(new string[] { "Map", "Terrain" });
    public static LayerMask terrainMask = LayerMask.GetMask(new string[] { "Terrain" });
    public static LayerMask mapMask = LayerMask.GetMask(new string[] { "Map" });
    public static LayerMask cameraMask = LayerMask.GetMask(new string[] { "Terrain", "OnlyCamera" });

    public static ConfigurableJoint AttatchObject(Rigidbody rigidbody1, Rigidbody rigidbody2)
    {
        ConfigurableJoint joint = rigidbody1.gameObject.AddComponent<ConfigurableJoint>();
        joint.xMotion = ConfigurableJointMotion.Limited;
        joint.yMotion = ConfigurableJointMotion.Limited;
        joint.zMotion = ConfigurableJointMotion.Limited;
        joint.angularXMotion = ConfigurableJointMotion.Limited;
        joint.angularYMotion = ConfigurableJointMotion.Limited;
        joint.angularZMotion = ConfigurableJointMotion.Limited;
        joint.connectedBody = rigidbody2;
        joint.projectionMode = JointProjectionMode.PositionAndRotation;
        return joint;
    }

    public enum MaskTarget
    {
        TerrainOnly,
        MapOnly,
        MapAndTerrain
    }


    public static Collider[] CheckBox(BoxCollider boxCollider)
    {
        if (!boxCollider)
            return null;

        return Physics.OverlapBox(boxCollider.transform.TransformPoint(boxCollider.center), Vector3.Scale(boxCollider.size, boxCollider.transform.lossyScale) * 0.5f, boxCollider.transform.rotation);
    }

    public static RaycastHit GroundCast(Vector3 position, Vector3 dir, int range)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(position, dir);

        Physics.Raycast(ray, out hit, range, mapAndTerrain);

        return hit;
    }

    public static bool LookingAt(Transform looker, Vector3 position)
    {
        return Vector3.Angle(looker.forward, position - looker.position) < 90;
    }

    public static void SetJointYZAngle(ConfigurableJoint joint, float y_Angle, float z_Angle)
    {
        SoftJointLimit lim = joint.angularYLimit;
        lim.limit = y_Angle;
        joint.angularYLimit = lim;

        lim = joint.angularZLimit;
        lim.limit = z_Angle;
        joint.angularZLimit = lim;
    }


    public static void SetJointXAngle(ConfigurableJoint joint, float x_Low, float x_High)
    {
        SoftJointLimit lim = joint.highAngularXLimit;
        lim.limit = x_High;
        joint.highAngularXLimit = lim;

        lim = joint.lowAngularXLimit;
        lim.limit = x_Low;
        joint.lowAngularXLimit = lim;
    }

    public static Vector3 GetRotationDelta(Vector3 ownForward, Vector3 targetForward)
    {
        Vector3 torque = Vector3.Cross(ownForward, targetForward).normalized * Vector3.Angle(ownForward, targetForward);

        return torque;
    }

    public static Vector3 GetDirectionBetweenTransforms(Vector3 from, Vector3 to)
    {
        return (to - from).normalized;
    }

    public static Vector3 GetRandomPointOnMap()
    {
        Vector3 randomPos = Vector3.zero;

        int tries = 100;
        while(randomPos == Vector3.zero && tries > 0)
        {
            float radius = 60;
            float height = 60;

            float x = UnityEngine.Random.Range(-radius, radius);
            float z = UnityEngine.Random.Range(-radius, radius);

            Vector3 skyPos = new Vector3(x, height, z);

            Vector3 groundPos = GetGroundPos(skyPos);

            if (groundPos != skyPos)
                randomPos = groundPos;

            tries--;
        }

        return randomPos;
    }

    public static bool IsInRange(Transform obj1, Transform obj2, int range)
    {
        return Vector3.Distance(obj1.position, obj2.position) < range;
    }


    public static Vector3 GetGroundPos(Vector3 pos, bool onlyTerrain = false)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(pos, Vector3.down);

        Physics.Raycast(ray, out hit, 100000, onlyTerrain ? terrainMask : mapAndTerrain);

        if(hit.transform)
        {
            return hit.point;
        }
        else
        {
            return pos;
        }
    }
    
    public static bool TryGetGroundPos(ref Vector3 pos, bool onlyTerrain = false)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(pos, Vector3.down);

        Physics.Raycast(ray, out hit, 100000, onlyTerrain ? terrainMask : mapAndTerrain);

        if(hit.transform)
        {
            pos =  hit.point;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Vector3 GetObstructionPoint(Vector3 from, Vector3 to, float radius = 0)
    {
        RaycastHit hit = GetObstructionPointRaycast(from, to, radius);

        if (hit.transform)
        {
            if (radius == 0)
                return hit.point;
            else
                return from + (to - from).normalized * hit.distance;
        }
        else
        {
            return to;
        }
    }

    public static RaycastHit GetObstructionPointRaycast(Vector3 from, Vector3 to, float radius = 0, bool overrideMask = false, LayerMask mask = default)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(from, to - from);

        if(radius == 0)
            Physics.Raycast(ray, out hit, Vector3.Distance(from, to), overrideMask ? mask : cameraMask);
        else
            Physics.SphereCast(ray, radius, out hit, Vector3.Distance(from, to), overrideMask ? mask : cameraMask);

        return hit;
    }
    
    public static RaycastHit GetGroundPosRaycast(Vector3 pos, bool onlyTerrain = false, Vector3 directionOffset = default)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(pos, Vector3.down + directionOffset);

        Physics.Raycast(ray, out hit, 100000, onlyTerrain ? terrainMask : mapAndTerrain);

        return hit;
    }

    public static bool CanSee(Vector3 from, Vector3 to, float radius = 0, MaskTarget maskType = MaskTarget.MapAndTerrain)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(from, to - from);

        LayerMask mask = mapAndTerrain;
        if (maskType == MaskTarget.MapOnly)
            mask = mapMask;
        else if (maskType == MaskTarget.TerrainOnly)
            mask = terrainMask;

        if (radius == 0)
            Physics.Raycast(ray, out hit, Vector3.Distance(from, to), mask);
        else
            Physics.SphereCast(ray, radius, out hit, Vector3.Distance(from, to), mask);


        if (hit.transform)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static RaycastHit GetMouseRaycast(bool onlyMap = false)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(onlyMap)
            Physics.Raycast(ray, out hit, 10000, mapAndTerrain);
        else
            Physics.Raycast(ray, out hit, 10000);


        return hit;
    }
}


public class RayHitData
{
    public Vector3 hitPoint;
    public Vector3 hitNormal;
    public Transform hitTransform;
    public Rigidbody hitRig;
    public Collider hitCol;
}

[System.Serializable]
public class RigWithMultiplier
{
    public Rigidbody rig;
    public float mutliplier = 1f;
}

public enum LeftRight
{
    Left,
    Right
}

public enum PP_Space
{
    Local,
    World,
    Hip,
    PlayerDirection
}

public enum PP_AnimationState
{
    Idle,
    Walk,
    Run
}