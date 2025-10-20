using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    static private Animator anim;
    void Awake() {
        anim = GetComponent<Animator>();
    }

    public static void PlayTrigger(string trigger) {
        anim.SetTrigger(trigger);
    }

    public static void PlayBool(string bName, bool b) {
        anim.SetBool(bName, b);
    }
	
	void OnDestroy() {
		anim = null;
	}
}
