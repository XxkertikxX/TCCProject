using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(transform.root.gameObject);
    }
}
