using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    static Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public static void PlayTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }
}
