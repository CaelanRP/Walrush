using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectColor : MonoBehaviour
{
    void Start()
    {
        SpawnedObject spawned = GetComponentInParent<SpawnedObject>();

        if (!spawned || spawned.color == Color.black)
            return;

        Color ownColor = Color.black;

        ParticleSystem part = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule main;

        float alpha = 1;

        if(part)
        {
            main = part.main;

            ownColor = main.startColor.color;
        }

        MeshRenderer rend = GetComponent<MeshRenderer>();
        if(rend)
        {
            ownColor = rend.material.GetColor("_EmissionColor");
        }

        alpha = ownColor.a;


        if (ownColor == Color.black)
            return;


        float myH = 1f, myS = 1f, myV = 1f;
        float newH = 1f, newS = 1f, newV = 1f;

        Color.RGBToHSV(ownColor, out myH, out myS, out myV);
        Color.RGBToHSV(spawned.color, out newH, out newS, out newV);

        myH = newH;
        myS = newS;

        ownColor = Color.HSVToRGB(myH, myS, myV);
        ownColor.a = alpha;

        if(rend)
        {
            rend.material.SetColor("_EmissionColor", ownColor);
        }
        if (part)
        {
            ParticleSystem.MinMaxGradient minMax = main.startColor;

            minMax.color = ownColor;
            minMax.colorMin = ownColor;
            minMax.colorMax = ownColor;

            main.startColor = minMax;
        }

    }
}
