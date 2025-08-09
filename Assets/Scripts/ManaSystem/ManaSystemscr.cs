using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystemscr : MonoBehaviour
{
    static private IManaUI manaUI;

    static private float maxMana = 100;
    static private float actualMana;

    void Awake() {
        PullComponents();
        actualMana = maxMana;
    }

    void Start() {
        manaUI.UpdateUI(actualMana, maxMana);
    }

    static public void ModifyMana(float manaChange) {
        actualMana = Mathf.Clamp(actualMana + manaChange, 0, maxMana);
        manaUI.UpdateUI(actualMana, maxMana);
    }

    private void PullComponents() {
        manaUI = GetComponent<IManaUI>();
    }
}
