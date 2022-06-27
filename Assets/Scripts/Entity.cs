using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Entity : MonoBehaviour
{
    protected Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    [BoxGroup("Movement Physics")]
    public float defaultXZDrag;
    [BoxGroup("Movement Physics")]
    public float defaultGravityMultiplier = 1;

    protected virtual void FixedUpdate(){
        UpdateDrag();
        UpdateGravity();
    }

    protected virtual void UpdateDrag(){
        Vector3 XZdrag = Util.ZeroY(rb.velocity) * -defaultXZDrag;
        rb.AddForce(XZdrag);
    }

    protected virtual void UpdateGravity(){
        Vector3 gravity = CameraController.Instance.currentDown * defaultGravityMultiplier * 9.8f;
        rb.AddForce(gravity);
    }
}
