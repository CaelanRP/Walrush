using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGamefeel : MonoBehaviour
{
    public List<GameFeelEffect> effects = new List<GameFeelEffect>();

    public bool auto = false;

    void Start()
    {
        if(auto)
            Go();
    }

    public void Go()
    {
        Gamefeel.instance.PlayEffects(effects, transform.position, transform.forward);
    }
}
