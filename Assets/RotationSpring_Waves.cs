using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class RotationSpring_Waves : MonoBehaviour
{
    RotationSpring spring;
    public float wavePeriod, waveAmplitude;

    public Transform boatPendulumPosition;

    Vector3 waveDirection;
    void Start()
    {
        spring = GetComponent<RotationSpring>();
        waveDirection = Vector3.right;
    }

    [ReadOnly]
    public float currentWaveMagnitude, sineTest;
    void Update()
    {
        currentWaveMagnitude = Mathf.Sin(Time.time / wavePeriod) * waveAmplitude;
        sineTest = Mathf.Sin(Time.time / wavePeriod);
        spring.AddForce_World(waveDirection * currentWaveMagnitude, boatPendulumPosition.position);
    }
}
