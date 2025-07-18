using UnityEngine;

public class LifeBase : MonoBehaviour
{
    protected LifeSystem lifeSystem;

    void Start() {
        lifeSystem = GetComponent<LifeSystem>();
        Inicialize();
    }
    
    protected virtual void Inicialize(){}
}
