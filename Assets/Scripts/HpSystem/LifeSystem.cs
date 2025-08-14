using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    private IDeath deathHandler;
    private ILifeUI lifeUI;

    private float maxLife;
    private float actualLife;

    void Start() {
        PullComponents();
        actualLife = maxLife;
        lifeUI.UpdateUI(actualLife, maxLife);
    }

    public void ModifyLife(float lifeChange) {
        actualLife = Mathf.Clamp(actualLife + lifeChange, 0, maxLife);
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