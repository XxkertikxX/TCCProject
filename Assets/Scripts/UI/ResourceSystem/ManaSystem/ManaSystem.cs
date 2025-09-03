using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    static public ResourceSystem Mp;
    private int level = 0;
    
    public void Constructor(ResourceSystem mp) {
        Mp = mp;
    }

    public void LevelUp() {
        level += 1;
        Mp = 10 + level;
    }
}