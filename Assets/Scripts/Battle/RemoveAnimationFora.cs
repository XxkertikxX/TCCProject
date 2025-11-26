using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAnimationFora : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] BattleApplyConfig battleConfig;


    void OnEnable() {
        RemoveAnimation.OnDisableAnimation += Remove;
    }

    void OnDisable() {
        RemoveAnimation.OnDisableAnimation -= Remove;
    }

    void Remove() {
        if (battleConfig.battleConfigSO.hasDialog) {
            return;
        }
        StartCoroutine(dis());
    }

    private IEnumerator dis() {
        yield return new WaitForSeconds(1f);
        anim.enabled = false;
    }
}
