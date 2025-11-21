using UnityEngine;
using UnityEngine.UI;

public class DinamicUIBar : MonoBehaviour, IDinamicUI
{
    [SerializeField] private Text valueText;
    [SerializeField] private Slider valueSlider;


    public void UpdateUI(float actualValue, float maxValue) {
        var roundValue = Mathf.Round(actualValue);
        valueText.text = $"{roundValue}/{maxValue}";
        valueSlider.value = roundValue;
    }
}