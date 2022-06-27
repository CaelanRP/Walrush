using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRILerp : MonoBehaviour {
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public static Vector3 Lerp (Vector3 from, Vector3 target, float speed, bool useTimeScale = true)
    {
        return Vector3.Lerp(from, target, 1.0f - Mathf.Exp(-speed * (useTimeScale ? Time.deltaTime : Time.unscaledDeltaTime)));
    }
    public static Vector3 PLerp (Vector3 from, Vector3 target, float speed, float dt)
    {
        return Vector3.Lerp(from, target, 1.0f - Mathf.Exp(-speed * dt));
    }
    public static Quaternion PLerp(Quaternion from, Quaternion target, float speed, float dt)
    {
        return Quaternion.Lerp(from, target, 1.0f - Mathf.Exp(-speed * dt));
    }
    public static float PLerp (float from, float target, float speed, float dt)
    {
        return Mathf.Lerp(from, target, 1.0f - Mathf.Exp(-speed * dt));
    }
    public static Vector3 LerpFixed (Vector3 from, Vector3 target, float speed, bool useTimeScale = true)
    {
        return Vector3.Lerp(from, target, 1.0f - Mathf.Exp(-speed * (useTimeScale ? Time.fixedDeltaTime : Time.unscaledDeltaTime)));
    }
    public static Vector3 LerpUnclamped(Vector3 from, Vector3 target, float speed)
    {
        return Vector3.LerpUnclamped(from, target, 1.0f - Mathf.Exp(-speed * Time.deltaTime));
    }

    public static float Lerp(float from, float target, float speed)
    {
        return Mathf.Lerp(from, target, 1.0f - Mathf.Exp(-speed * Time.deltaTime));
    }
    public static float LerpUnclamped(float from, float target, float speed)
    {
        return Mathf.LerpUnclamped(from, target, 1.0f - Mathf.Exp(-speed * Time.deltaTime));
    }

    public static Vector3 Slerp(Vector3 from, Vector3 target, float speed)
    {
        return Vector3.Slerp(from, target, 1.0f - Mathf.Exp(-speed * Time.deltaTime));
    }
    public static Vector3 SlerpUnclamped(Vector3 from, Vector3 target, float speed)
    {
        return Vector3.SlerpUnclamped(from, target, 1.0f - Mathf.Exp(-speed * Time.deltaTime));
    }

    // Update is called once per frame
    public static Quaternion Lerp(Quaternion from, Quaternion target, float speed)
    {
        return Quaternion.Lerp(from, target, 1.0f - Mathf.Exp(-speed * Time.deltaTime));
    }
    public static Quaternion LerpUnclamped(Quaternion from, Quaternion target, float speed)
    {
        return Quaternion.LerpUnclamped(from, target, 1.0f - Mathf.Exp(-speed * Time.deltaTime));
    }
}
