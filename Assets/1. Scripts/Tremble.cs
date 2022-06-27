using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tremble : MonoBehaviour
{

    float currentTremble;
    float currentDuration;

    float currentMaxDur = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if(currentDuration > 0)
        {
            currentDuration -= Time.deltaTime;

            transform.localPosition = Random.insideUnitSphere * ActiveTremble() * 0.15f;
            transform.localEulerAngles = Random.insideUnitSphere * ActiveTremble() * 5f;
        }
    }

    float ActiveTremble()
    {
        return currentTremble * (currentDuration / currentMaxDur); ;
    }

    public void AddTremble(float amount, float duration, Vector3 pos = default, float range = 0)
    {

        if (range != 0)
        {
            float dist = Vector3.Distance(pos, Camera.main.transform.position);

            if (dist > range)
                return;

            amount *= Mathf.Clamp((1f - (dist / range)), 0f, 1f);
        }


        if (amount > ActiveTremble())
        {
            currentTremble = amount;
            currentDuration = duration;
            currentMaxDur = duration;
        }
    }
}
