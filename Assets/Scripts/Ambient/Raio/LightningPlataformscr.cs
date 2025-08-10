using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LightningPlataformscr : MonoBehaviour, IEnviromentProperty
{
    [SerializeField] private Rigidbody2D platformRb;
    [SerializeField] private float delay = 3f;
    [SerializeField] private float targetGravity = 1f;
    private ParticleSystem thunderParticle;

    private void Start()
    {
        platformRb.constraints = RigidbodyConstraints2D.FreezeAll;
        thunderParticle = GetComponentInChildren<ParticleSystem>(); 
        thunderParticle.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerArea"))
        {
             StartCoroutine(ApplyEffect(platformRb));
        }
    }

    public IEnumerator ApplyEffect(Rigidbody2D targetRB)
    {
        thunderParticle.Play();
        yield return new WaitForSeconds(delay);
        thunderParticle.Stop();
        targetRB.gravityScale = targetGravity;
        targetRB.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }
}