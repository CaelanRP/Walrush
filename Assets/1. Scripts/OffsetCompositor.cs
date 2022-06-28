using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetCompositor : MonoBehaviour
{
    public Transform objectParent;
    public List<Transform> objs;

    public static OffsetCompositor instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        for (int i = 0; i < objectParent.childCount; i++)
        {
            objs.Add(objectParent.GetChild(i));
        }
    }

    void Update()
    {
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;

        for (int i = 0; i < objs.Count; i++)
        {
            transform.localPosition += objs[i].localPosition;
            transform.localEulerAngles += objs[i].localEulerAngles;
        }
    }
}
