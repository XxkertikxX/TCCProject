using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour, ILifeUI
{
    [SerializeField] private Text lifeText;
    [SerializeField] private Slider lifeSlider;

    public void UpdateUI(float actualLife, float maxLife) {
        lifeText.text = $"{actualLife}/{maxLife}";
        lifeSlider.value = actualLife / maxLife;
    }
}