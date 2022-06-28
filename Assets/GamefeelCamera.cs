using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamefeelCamera : MonoBehaviour
{


    void LateUpdate()
    {
        transform.localRotation = OffsetCompositor.instance.transform.localRotation;
        transform.localPosition = OffsetCompositor.instance.transform.localPosition;
    }
}
