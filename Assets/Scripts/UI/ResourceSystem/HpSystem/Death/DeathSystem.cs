using UnityEngine;

public class DeathSystem : MonoBehaviour
{
    private ResourceSystem lifeSystem;
    private IDeath deathHandler;

    public void Constructor(ResourceSystem lifeSystem, IDeath deathHandler) {
        this.lifeSystem = lifeSystem;
        this.deathHandler = deathHandler;
    }
    
    void Start() {
        lifeSystem.OnResourceEmpty += deathHandler.Death;
    }
    
    void OnDisable() {
        lifeSystem.OnResourceEmpty -= deathHandler.Death;
    }
}