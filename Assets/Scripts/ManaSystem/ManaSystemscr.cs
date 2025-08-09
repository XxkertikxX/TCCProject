using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystemscr : MonoBehaviour
{
    private IManaUI manaUI;

    private float maxMana;
    private float actualMana;

    void Awake()
    {
        PullComponents();
        actualMana = maxMana;
    }

    void Start()
    {
        manaUI.UpdateUI(actualMana, maxMana);
    }

    public void ModifyMana(float manaChange)
    {
        actualMana = Mathf.Clamp(actualMana + manaChange, 0, maxMana);
        manaUI.UpdateUI(actualMana, maxMana);
    }

    private void PullComponents()
    {
        maxMana = GetComponent<CharacterAttributes>().Character.hp;
        manaUI = GetComponent<IManaUI>();
    }
}
