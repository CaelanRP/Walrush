using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public Camera cam;
    public static CameraController Instance;

    public float horizontalLerpRate, depthLerpRate;
    void OnEnable(){
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    Vector3 target;
    void LateUpdate()
    {
        target.x = Walrus.Instance.transform.position.x;
        target.z = Walrus.Instance.transform.position.z;

        float x = Mathf.Lerp(transform.position.x, target.x, horizontalLerpRate * Time.deltaTime);
        float z = Mathf.Lerp(transform.position.z, target.z, depthLerpRate * Time.deltaTime);
        transform.position = new Vector3(x,transform.position.y, z);
    }

    public Vector3 currentDown{
        get{
            return -transform.up;
        }
    }
}
