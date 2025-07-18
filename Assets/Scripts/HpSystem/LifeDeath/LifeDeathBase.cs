public class LifeDeathBase : LifeBase
{
    void OnEnable() {
        lifeSystem.OnDeath += Death;
    }

    void OnDisable() {
        lifeSystem.OnDeath -= Death;
    }
    
    protected virtual void Death() {
        Destroy(gameObject);   
    }
}
