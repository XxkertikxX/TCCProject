using UnityEngine;
using UnityEngine.UI;

public class LifeBar : LifeUIBase
{
    [SerializeField] private Text lifeText;
    [SerializeField] private Slider lifeSlider;

    protected override void UpdateUI() {
        lifeText.text = $"{lifeSystem.ActualLife}/{lifeSystem.MaxLife}";
        lifeSlider.value = lifeSystem.ActualLife / lifeSystem.MaxLife;
    }
}