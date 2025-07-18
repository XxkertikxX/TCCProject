using UnityEngine;

public abstract class LifeUIBase : MonoBehaviour
{
    protected LifeSystem lifeSystem;

    void Start() {
        lifeSystem = GetComponent<LifeSystem>();
        UpdateUI();
    }

    void OnEnable() {
        lifeSystem.OnLifeChanged += UpdateUI;
        lifeSystem.OnDeath += Death;
    }

    void OnDisable() {
        lifeSystem.OnLifeChanged -= UpdateUI;
        lifeSystem.OnDeath -= Death;
    }

    protected abstract void UpdateUI();
    
    protected virtual void Death() {
        Destroy(gameObject);   
    }
}
