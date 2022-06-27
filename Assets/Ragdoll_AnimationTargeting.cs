using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_AnimationTargeting : MonoBehaviour
{
    public Transform rigRelativeTo;
    public Transform targetRelativeTo;
    public RigTargets[] rigTargets;
    public float followForce;
    public float followForceTorque;

    [System.Serializable]
    public class RigTargets
    {
        public Rigidbody rig;
        public Transform target;
    }


    void FixedUpdate()
    {
        float forceM = 1;

        for (int i = 0; i < rigTargets.Length; i++)
        {

            Vector3 relPos = targetRelativeTo.InverseTransformPoint(rigTargets[i].target.position);
            Vector3 targetPos = rigRelativeTo.TransformPoint(relPos);

            //targetPos = rigTargets[i].target.position;

            Vector3 force = targetPos - rigTargets[i].rig.position;

            rigTargets[i].rig.AddForce(force * followForce * forceM, ForceMode.Acceleration);


            Vector3 torque = Vector3.Cross(rigTargets[i].rig.transform.forward, rigTargets[i].target.transform.forward) * Vector3.Angle(rigTargets[i].rig.transform.forward, rigTargets[i].target.transform.forward);
            torque += Vector3.Cross(rigTargets[i].rig.transform.up, rigTargets[i].target.transform.up) * Vector3.Angle(rigTargets[i].rig.transform.up, rigTargets[i].target.transform.up);

            rigTargets[i].rig.AddTorque(torque * followForceTorque * forceM, ForceMode.Acceleration);

        }
    }
}
