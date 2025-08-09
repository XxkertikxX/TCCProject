using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpModifierscr : MonoBehaviour
{
    private float maxMana;
    private float actualMana;

    static public void ModifyMana(int manachange)
    {
        actualMana += manachange;
    }
}
