using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    static public ResourceSystem Mp;
    
    public void Constructor(ResourceSystem mp) {
        Mp = mp;
    }
}