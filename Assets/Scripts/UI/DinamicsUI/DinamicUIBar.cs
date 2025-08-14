using UnityEngine;
using UnityEngine.UI;

public class DinamicUIBar : MonoBehaviour, IDinamicUI
{
    [SerializeField] private Text valueText;
    [SerializeField] private Slider valueSlider;

    public void UpdateUI(float actualValue, float maxValue) {
        valueText.text = $"{actualValue}/{maxValue}";
        valueSlider.value = actualValue / maxValue;
    }
}