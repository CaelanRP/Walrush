using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalrusAnimatorHelper : MonoBehaviour
{
    public Walrus walrus;
    void Awake(){
        walrus = GetComponentInParent<Walrus>();
    }

    public void Step(){
        walrus.Step();
    }
}
