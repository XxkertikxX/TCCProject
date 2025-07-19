using UnityEngine;

public class DestroyDeath : MonoBehaviour, IDeath
{
    public void Death() {
        Destroy(gameObject);
    }
}