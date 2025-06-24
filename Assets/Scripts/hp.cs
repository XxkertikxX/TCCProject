using UnityEngine;

public class hp : MonoBehaviour
{
    StatusCharacters Character;
    float life;

    void Start() {
        Character = GetComponent<CharacterStatus>().character;
        life = Character.hp;
    }

    public void TakeDamage(float Damage) {
        life -= Damage;
        if (IsDead()) {
            Destroy(gameObject);
        }
    }

    public void Heal(float heal) {
        life += heal;
    }

    bool IsDead() {
        if (life <= 0) {
            return true;
        }
        return false;
    }
}