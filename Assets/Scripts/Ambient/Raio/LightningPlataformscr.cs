using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LightningPlataformscr : MonoBehaviour, IEnviromentProperty
{
    [SerializeField] private Rigidbody2D platformRb;
    [SerializeField] private float delay = 3f;
    [SerializeField] private float targetGravity = 1f;

    private void Start()
    {
        platformRb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerArea"))
        {
             StartCoroutine(ApplyEffect(platformRb));
        }
    }

    public IEnumerator ApplyEffect(Rigidbody2D targetRB)
    {
        yield return new WaitForSeconds(delay);
        targetRB.gravityScale = targetGravity;
        targetRB.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }
}