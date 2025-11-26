using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAnimationFora : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void OnEnable() {
        RemoveAnimation.OnDisableAnimation += Remove;
    }

    void OnDisable() {
        RemoveAnimation.OnDisableAnimation -= Remove;
    }

    void Remove() {
        StartCoroutine(dis());
    }

    private IEnumerator dis() {
        yield return new WaitForSeconds(1f);
        anim.enabled = false;
    }
}
