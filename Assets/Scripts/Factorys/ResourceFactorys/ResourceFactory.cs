using UnityEngine;

public class ResourceFactory
{
    public static ResourceSystem CreateResourceSystem(GameObject target, float maxValue) {
        ResourceSystem resourceSystem = target.AddComponent<ResourceSystem>();
        resourceSystem.Constructor(maxValue);
        return resourceSystem;
    }
}
