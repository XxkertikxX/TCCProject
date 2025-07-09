using UnityEngine;
using UnityEngine.UI;

public class hp : MonoBehaviour
{
    [SerializeField] private Text lifeText;
    [SerializeField] private Slider lifeSlider;

    private StatusCharacters character ;
    private float life;

    void Start() {
        character = GetComponent<CharacterStatus>().Character;
        life = character.Hp;
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

    private bool IsDead() {
        if (life <= 0) {
            return true;
        }
        return false;
    }

    private void UpdateUI(){
        lifeText.text = $"{life}/{character.Hp}";
        lifeSlider.value = life / character.Hp;
    }
}