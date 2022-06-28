using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;
    public ParticleSystem[] vfx;

    float slowMoTime = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;


    }


    private void Update()
    {
        if (slowMoTime > 0)
        {
            slowMoTime -= Time.unscaledDeltaTime;
            Time.timeScale = 0.1f;
            //Time.fixedTimeScale = (1f/60f) / 0.2f;
        }
        else
        {
            Time.timeScale = 1;
            //Time.fixedTimeScale = (1f / 60f) / 0.2f;
        }
    }


    public void SpawnHit(Vector3 pos, Vector3 forward)
    {
        vfx[0].transform.position = pos;
        vfx[0].transform.forward = forward;
        vfx[0].Play();
        Invoke("Crimes", 0.1f);
    }

    void Crimes()
    {
        if (slowMoTime <= 0)
        {
            slowMoTime = 0.1f;
        }
    }
}
