using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    public Vector2 windDirection;
    public float windForce;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision == null || collision.gameObject.tag != "Player")
        {
            return;
        }
        Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
        playerRB.AddForce(windDirection * windForce);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null || collision.gameObject.tag != "Player")
        {
            return;
        }
        Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Momentum(playerRB));
    }

    IEnumerator Momentum(Rigidbody2D playerRB)
    {
        float timing = 1f;
        while (timing > 0f)
        {
            playerRB.velocity -= windDirection * Time.deltaTime * windForce * 0.01f; //arrumar loop do ciclo de vento
            Debug.Log(playerRB.velocity);
            timing -= Time.deltaTime;
            yield return null;
        }
    }
}
