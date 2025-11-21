using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(transform.root.gameObject);
    }
    
    public void DestroySpriteRender()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());
    }
}
