using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    float Life;

    public void TakeDamage(float Damage) {
        Life -= Damage;
    }
}
