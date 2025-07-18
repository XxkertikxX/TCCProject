using System;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public event Action OnLifeChanged;
    public event Action OnDeath;

    private float maxLife;
    private float actualLife;

    public float MaxLife => maxLife;
    public float ActualLife => actualLife;

    void Awake() {
        maxLife = GetComponent<CharacterStatus>().Character.hp;
        actualLife = maxLife;
    }
        
    public void AddLife(float life) {            
        actualLife = Mathf.Clamp(actualLife + life, 0, maxLife);
        OnLifeChanged?.Invoke();
        InvokeEventOnDeath();
    }
    
    private void InvokeEventOnDeath() {
        if (actualLife == 0) {
            OnDeath?.Invoke();
        }
    }      
}