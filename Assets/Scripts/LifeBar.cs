using UnityEngine;
using UnityEngine.UI;

public class LifeBar : hp
{
    [SerializeField] private Text lifeText;
    [SerializeField] private Slider lifeSlider;

    void Start() {
        UpdateUI();
    }

    void OnEnable() {
        OnLifeChanged += UpdateUI;
        OnDeath += Death;
    }

    void OnDisable() {
        OnLifeChanged -= UpdateUI;
        OnDeath -= Death;
    }

    private void UpdateUI() {
        lifeText.text = $"{life}/{character.Hp}";
        lifeSlider.value = life / character.Hp;
    }

    private void Death() => Destroy(gameObject);
}