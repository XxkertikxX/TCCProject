    using System;
    using UnityEngine;

    public class hp : MonoBehaviour
    {
        protected event Action OnLifeChanged;

        protected StatusCharacters character;
        protected float life;

        void Start() {
            character = GetComponent<CharacterStatus>().Character;
            life = character.Hp;
        }
        
        public void AddLife(float life) {            
            this.life += life;
            OnLifeChanged?.Invoke();
            if (IsDead()) {
                Destroy(gameObject);
            }
        }

        private bool IsDead() {
            if (life <= 0) {
                return true;
            }
            return false;
        }
    }