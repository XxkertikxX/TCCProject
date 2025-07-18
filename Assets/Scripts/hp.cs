using System;
using UnityEngine;

public class hp : MonoBehaviour
{
    protected event Action OnLifeChanged;
    protected event Action OnDeath;

    protected StatusCharacters character;
    protected float life;

    void Start() {
        character = GetComponent<CharacterStatus>().Character;
        life = character.Hp;
    }
        
    public void AddLife(float life) {            
        this.life += life;
        OnLifeChanged?.Invoke();
        InvokeEventOnDeath();
    }
    
    private void InvokeEventOnDeath() {
        if (life <= 0) {
            OnDeath?.Invoke();
        }
    }      
}