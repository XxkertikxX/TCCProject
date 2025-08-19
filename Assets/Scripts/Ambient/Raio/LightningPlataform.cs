using System.Collections;
using UnityEngine;

public class LightningPlataform : MonoBehaviour
{
    [SerializeField] private float delay = 3f;
    private Rigidbody2D platformRb;
    private float targetGravity = 1f;
    private ParticleSystem thunderParticle;

    private void Start() {
        platformRb = GetComponent<Rigidbody2D>();
        platformRb.constraints = RigidbodyConstraints2D.FreezeAll;
        thunderParticle = GetComponentInChildren<ParticleSystem>(); 
        thunderParticle.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("PlayerArea")) {
             StartCoroutine(ApplyEffect(platformRb));
        }
    }

    private IEnumerator ApplyEffect(Rigidbody2D targetRB) {
        thunderParticle.Play();
        yield return new WaitForSeconds(delay);
        thunderParticle.Stop();
        targetRB.gravityScale = targetGravity;
        targetRB.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
    }
}