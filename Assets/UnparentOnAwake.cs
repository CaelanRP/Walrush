using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentOnAwake : MonoBehaviour
{
    void Awake()
    {
        transform.SetParent(null);
    }
}
