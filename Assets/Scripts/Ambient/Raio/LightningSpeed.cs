using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpeed : MonoBehaviour
{
    [SerializeField] private float Duration = 13f;
    private MovementProperties movementProperties;

    private void Awake() {
        movementProperties = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementProperties>();
    }

    private IEnumerator ApplyEffect() {
        movementProperties.MultiplierSpeed = 2;
        yield return new WaitForSeconds(Duration);
        movementProperties.MultiplierSpeed = 1;
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            StartCoroutine(ApplyEffect());
        }
    }
}