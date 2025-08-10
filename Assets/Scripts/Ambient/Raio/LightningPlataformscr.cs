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
        yield return new WaitForSeconds(delay);
        StartCoroutine(Particle());
        targetRB.gravityScale = targetGravity;
        targetRB.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }
    IEnumerator Particle()
    {
        thunderParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        thunderParticle.gameObject.SetActive(false);
    }
}