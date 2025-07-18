public abstract class LifeUIBase : LifeBase
{
    protected override void Inicialize() {
        UpdateUI();
    }

    void OnEnable() {
        lifeSystem.OnLifeChanged += UpdateUI;
    }

    void OnDisable() {
        lifeSystem.OnLifeChanged -= UpdateUI;
    }

    protected abstract void UpdateUI();
}
