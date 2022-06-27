using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamefeel : MonoBehaviour
{
    public static Gamefeel instance;
    void Awake()
    {
        instance = this;
    }

    internal void PlayEffects(List<GameFeelEffect> effects, Vector3 pos, Vector3 direction = default)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            StartCoroutine(IPlayEffects(effects[i]));
        }

        IEnumerator IPlayEffects(GameFeelEffect effect)
        {
            if(effect.timing > 0)
                yield return new WaitForSeconds(effect.timing);

            if (effect.effectType == GameFeelEffect.EffectType.Shake_World)
                AddRotationShake_World(direction * effect.worldShakeAmount, pos, effect.worldShakeRange);


            if (effect.effectType == GameFeelEffect.EffectType.Tremble)
                AddTremble(effect.trembleAmount, effect.trembleDuration, pos, effect.trembleRange);

            if (effect.effectType == GameFeelEffect.EffectType.ObjectEnabler)
                EnableObjects(effect.objectsKey, effect.objectsDuration, pos, effect.objectsRange);

            if (effect.effectType == GameFeelEffect.EffectType.UnityEvent)
                effect.unityEvent.Invoke();

        }
    }

    public PositionSpring posSpring;
    public void AddPositonShake(Vector3 dir)
    {
        posSpring.AddForce(dir);
    }

    

    public RotationSpring rotSpring;
    public void AddRotationShake_World(Vector3 dir, Vector3 pos, float range = 0)
    {
        rotSpring.AddForce_WorldCamera(dir, pos, range);
    }


    public Tremble tremble;
    public void AddTremble(float amount, float duration, Vector3 pos = default, float range = 0)
    {
        tremble.AddTremble(amount, duration, pos, range);
    }


    public ObjectEnabler objectEnabler;
    internal Action<int> shootAction;

    public void Shoot(int power)
    {
        shootAction?.Invoke(power);
    }

    public void EnableObjects(string objectsKey, float duration, Vector3 pos = default, float range = 0)
    {
        objectEnabler.EnableObjects(objectsKey, duration, pos, range);
    }

    /*
    public PostEffectManager postEffectManager;
    public void AddDarkness(Vector3 pos, float range = 0)
    {
        postEffectManager.AddDarkness(dir, pos, range);
    }
    */
}



[System.Serializable]
public class GameFeelEffect
{
    public enum EffectType
    {
        Shake_World,
        Tremble,
        ObjectEnabler,
        UnityEvent
    }
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public EffectType effectType;
    [Space(10)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public float timing = 0;


    [Sirenix.OdinInspector.ShowIf("$effectType", EffectType.Shake_World)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public float worldShakeAmount = 1f;
    [Sirenix.OdinInspector.ShowIf("$effectType", EffectType.Shake_World)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public float worldShakeRange = 100f;

    [Sirenix.OdinInspector.ShowIf("$effectType", EffectType.Tremble)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public float trembleAmount = 1;
    [Sirenix.OdinInspector.ShowIf("$effectType", EffectType.Tremble)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public float trembleDuration = 0.1f;
    [Sirenix.OdinInspector.ShowIf("$effectType", EffectType.Tremble)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public float trembleRange = 100;



    [Sirenix.OdinInspector.ShowIf("$effectType", EffectType.ObjectEnabler)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public string objectsKey = "";
    [Sirenix.OdinInspector.ShowIf("$effectType", EffectType.ObjectEnabler)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public float objectsDuration = 0.1f;
    [Sirenix.OdinInspector.ShowIf("$effectType", EffectType.ObjectEnabler)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public float objectsRange = 30;


    [Sirenix.OdinInspector.ShowIf("$effectType", EffectType.UnityEvent)]
    [Sirenix.OdinInspector.FoldoutGroup("$timing")]
    public UnityEngine.Events.UnityEvent unityEvent;


}
