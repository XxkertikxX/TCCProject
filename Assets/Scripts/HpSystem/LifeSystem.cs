using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    private IDeath deathHandler;
    private ILifeUI lifeUI;

    private float maxLife;
    private float actualLife;

    void Awake() {
        PullComponents();
        actualLife = maxLife;
    }

    void Start() {
        lifeUI.UpdateUI(actualLife, maxLife);
    }

    public void AddLife(float life) {
        actualLife = Mathf.Clamp(actualLife + life, 0, maxLife);
        lifeUI.UpdateUI(actualLife, maxLife);
        if (actualLife == 0) {
            deathHandler.Death();
        }
    }
    
    private void PullComponents() {
        maxLife = GetComponent<CharacterAttributes>().Character.hp;
        deathHandler = GetComponent<IDeath>();
        lifeUI = GetComponent<ILifeUI>();
    }
}