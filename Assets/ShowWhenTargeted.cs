using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhenTargeted : MonoBehaviour
{
    Ragdoll ragdoll;
    public UnityEngine.Events.UnityEvent getTargetEvent;
    float targetFor = 0;
    void Start()
    {
        ragdoll = GetComponentInParent<Ragdoll>();
    }

    void Update()
    {
        if(ragdoll.data.target)
        {
            if(targetFor == 0)
            {
                getTargetEvent.Invoke();
            }
            targetFor += Time.deltaTime;
        }
        else
        {
            targetFor = 0;
        }

        if(targetFor > 0.3f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * 10);

        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 10);

        }
    }
}
