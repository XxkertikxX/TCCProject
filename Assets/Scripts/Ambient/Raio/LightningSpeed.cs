using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpeed : MonoBehaviour, IEnviromentProperty
{
    [SerializeField] Rigidbody2D playerrb;
    [SerializeField] public PlayerMovementWalk playerMovementWalk;
    [SerializeField] float LightSpeed = 10;
    [SerializeField] float Duration = 13;
    private bool Got = false;
    private float Speed;

    private void Start()
    {
        Speed = playerMovementWalk.speed;
    }

    public IEnumerator ApplyEffect(Rigidbody2D targetRB)
    {
        playerMovementWalk.speed = LightSpeed;
        yield return new WaitForSeconds(Duration);
        playerMovementWalk.speed = Speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ApplyEffect(playerrb));
        }
    }
}