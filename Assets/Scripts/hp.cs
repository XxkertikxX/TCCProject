using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    StatusCharacters Character;
    float life;
    [SerializeField] Text lifeText;
    [SerializeField] Slider lifeSlider;

    void Start() {
        Character = GetComponent<CharacterStatus>().character;
        life = Character.hp;
    }


    void Update() {
        UpdateUI();
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

    void UpdateUI(){
        lifeText.text = $"{life}/{Character.hp}";
        lifeSlider.value = life / Character.hp;
    }
}