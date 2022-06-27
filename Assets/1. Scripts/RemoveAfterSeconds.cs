
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterSeconds : MonoBehaviour
{
    public float seconds = 3f;
    public float randomFactor = 0f;
    public bool shrink = false;
    [Sirenix.OdinInspector.ShowIf("shrink")]
    public AnimationCurve shrinkCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    [Sirenix.OdinInspector.ShowIf("shrink")]
    public float shrinkTime = 0.3f;
    private void Start()
    {
        seconds += Random.Range(-seconds * randomFactor, seconds * randomFactor);
    }


    bool done = false;

    public void SetValues(float secondsToSet, bool shrinkToSet)
    {
        seconds = secondsToSet;
        shrink = shrinkToSet;
    }
    void Update()
    {
        if (done)
            return;

        seconds -= Time.deltaTime;

        if(seconds < 0)
        {
            StartCoroutine(RemoveObject());
        }
    }

    IEnumerator RemoveObject()
    {
        if(shrink)
        {

            Vector3 startScale = transform.localScale;
            Vector3 targetScale = Vector3.zero;
            float c = 0;
            float t = shrinkCurve.keys[shrinkCurve.length - 1].time;
            while(c < t)
            {
                c += Time.deltaTime / shrinkTime;
                transform.localScale = Vector3.Lerp(startScale, targetScale, shrinkCurve.Evaluate(c));
                yield return null;
            }
        }

        Destroy(gameObject);
    }
}
