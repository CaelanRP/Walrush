using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public Camera cam;
    public static CameraController Instance;
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
    void Update()
    {
        
    }

    public Vector3 currentDown{
        get{
            return -transform.up;
        }
    }
}
