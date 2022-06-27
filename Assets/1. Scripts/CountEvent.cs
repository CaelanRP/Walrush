using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEvent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent countEvent;
    float startSeconds;
    public float seconds = 0;
    public bool repeat = false;

    void Start()
    {
        startSeconds = seconds;
    }

    void Update()
    {
        seconds -= Time.deltaTime;    

        if(seconds < 0)
        {
            countEvent.Invoke();

            if(!repeat)
            {
                this.enabled = false;
            }
            else
            {
                seconds = startSeconds;
            }

        }
    }
}
