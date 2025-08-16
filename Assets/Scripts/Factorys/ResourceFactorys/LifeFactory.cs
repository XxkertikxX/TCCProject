using UnityEngine;

public class LifeFactory : MonoBehaviour
{
    void Awake() {
        CharacterAttributes characterAttr = GetComponent<CharacterAttributes>();
        float life = characterAttr.Character.Life;
        ResourceSystem lifeSystem = ResourceFactory.CreateResourceSystem(gameObject, life);
        characterAttr.LifeSystem = lifeSystem;
        CreateDeathSystem(lifeSystem);
    }

    private void CreateDeathSystem(ResourceSystem lifeSystem) {
        DeathSystem deathSystem = gameObject.AddComponent<DeathSystem>();
        deathSystem.Constructor(lifeSystem, GetComponent<IDeath>());
    }
}
