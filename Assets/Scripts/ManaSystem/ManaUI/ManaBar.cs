using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Text manaText;
    [SerializeField] private Slider manaSlider;

    public void UpdateUI(float actualMana, float maxMana)
    {
        manaText.text = $"{actualMana}/{maxMana}";
        manaSlider.value = actualMana / maxMana;
    }
}
