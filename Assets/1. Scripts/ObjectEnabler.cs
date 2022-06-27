using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnabler: MonoBehaviour
{

    public List<GameObject> toggleObjects = new List<GameObject>();

    internal List<ObjectEnableInstance> objectsToEnable = new List<ObjectEnableInstance>();

    private void Awake()
    {
        for (int i = 0; i < toggleObjects.Count; i++)
        {
            ObjectEnableInstance OTE = new ObjectEnableInstance();
            OTE.objectToEnable = toggleObjects[i];
            OTE.objectsKey = toggleObjects[i].name;
            objectsToEnable.Add(OTE);
        }
    }

    internal void EnableObjects(string objectsKey, float duration, Vector3 pos, float range)
    {

        for (int i = 0; i < objectsToEnable.Count; i++)
        {
            if(objectsToEnable[i].objectsKey == objectsKey)
            {
                if (objectsToEnable[i].currentPlaying != null)
                    StopCoroutine(objectsToEnable[i].currentPlaying);

                objectsToEnable[i].currentPlaying = StartCoroutine(ToggleObjects(objectsToEnable[i].objectToEnable, duration));
            }
        }
    }

    IEnumerator ToggleObjects(GameObject objectToEnable, float duration)
    {
        objectToEnable.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        objectToEnable.gameObject.SetActive(false);
    }

    [System.Serializable]
    public class ObjectEnableInstance
    {
        public string objectsKey = "";
        public GameObject objectToEnable;

        public Coroutine currentPlaying;
    }
}