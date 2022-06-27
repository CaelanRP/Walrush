using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{

    public GameObject spawner;
    public Color color = Color.black;

    public static GameObject ConfigureNewObject(GameObject newObject, GameObject spawner)
    {
        SpawnedObject newObjectScript = newObject.AddComponent<SpawnedObject>();

        SpawnedObject spawnerScript = spawner.GetComponent<SpawnedObject>();




        if(spawnerScript)
        {
            newObjectScript.spawner = spawnerScript.spawner;
            newObjectScript.color = spawnerScript.color;
        }
        else
        {
            newObjectScript.spawner = spawner;

            Effectable target = spawner.GetComponent<Effectable>();
        }

        return newObject;
    }
}
