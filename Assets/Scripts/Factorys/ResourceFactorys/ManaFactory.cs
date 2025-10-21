using UnityEngine;

public class ManaFactory : MonoBehaviour
{
    [SerializeField] private ManaSO manaSO;
    
    void Awake() {
        ResourceSystem resourceSystem = ResourceFactory.CreateResourceSystem(gameObject, manaSO.Mana);
        CreateManaSystem(resourceSystem);
    }
    
    private void CreateManaSystem(ResourceSystem resourceSystem) {
        ManaSystem manaSystem = gameObject.AddComponent<ManaSystem>();
        manaSystem.Constructor(resourceSystem);
    }
}