using UnityEngine;
using LiteDB;

public class ManaFactory : MonoBehaviour
{
    void Awake() {
        SaveSystem saveSystem = new SaveSystem();
        ResourceSystem resourceSystem = ResourceFactory.CreateResourceSystem(gameObject, saveSystem.OpenLoad().ManaTotal);
        CreateManaSystem(resourceSystem);
    }
    
    private void CreateManaSystem(ResourceSystem resourceSystem) {
        ManaSystem manaSystem = gameObject.AddComponent<ManaSystem>();
        manaSystem.Constructor(resourceSystem);
    }
}