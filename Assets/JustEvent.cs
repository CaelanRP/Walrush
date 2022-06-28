using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustEvent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent justEvent;
    public void JustDoEvent()
    {
        justEvent.Invoke();
    }
}
