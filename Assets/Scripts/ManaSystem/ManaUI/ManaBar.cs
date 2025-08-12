using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour, IManaUI
{
    [SerializeField] private Text manaText;
    [SerializeField] private Slider manaSlider;
    Button test;

    public void UpdateUI(float actualMana, float maxMana)
    {
        manaText.text = $"{actualMana}/{maxMana}";
        manaSlider.value = actualMana;
    }
}
