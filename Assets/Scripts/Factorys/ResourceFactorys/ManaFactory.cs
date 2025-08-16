using UnityEngine;

public class ManaFactory : MonoBehaviour
{
    void Awake() {
        ResourceSystem resourceSystem = ResourceFactory.CreateResourceSystem(gameObject, 100);
        CreateManaSystem(resourceSystem);
    }
    
    private void CreateManaSystem(ResourceSystem resourceSystem) {
        ManaSystem manaSystem = gameObject.AddComponent<ManaSystem>();
        manaSystem.Constructor(resourceSystem);
    }
}