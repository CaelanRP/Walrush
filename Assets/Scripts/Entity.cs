using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Entity : MonoBehaviour
{
    protected Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    [BoxGroup("Movement Physics")]
    public float defaultXZDrag;

    public virtual float XZDrag{
        get{
            return defaultXZDrag;
        }
    }
    [BoxGroup("Movement Physics")]
    public float defaultGravityMultiplier = 1;

    [Range(0,1)]
    public float directionalGravityRatio = 1;

    protected virtual void FixedUpdate(){
        UpdateDrag();
        UpdateGravity();
    }

    protected virtual void UpdateDrag(){
        Vector3 drag = Util.ZeroY(rb.velocity) * -XZDrag;
        rb.AddForce(drag);
    }

    protected virtual void UpdateGravity(){
        Vector3 gravity = CameraController.Instance.currentDown * defaultGravityMultiplier * 19.6f * rb.mass;
        rb.AddForce(gravity);
    }
}
