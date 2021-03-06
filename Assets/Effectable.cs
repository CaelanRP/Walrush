using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effectable : MonoBehaviour
{

    public abstract void TakeDamage(float damage, Vector3 direction = default);

    public abstract void AddForce(Vector3 force);

}
