using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnShiftR : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
            Application.LoadLevel(Application.loadedLevel);
        
    }
}
