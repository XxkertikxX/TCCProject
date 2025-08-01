using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    float windSpeed = .5f;
    public float windDistance = 10f;
    public Vector2 windDirection;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision == null || collision.gameObject.tag != "Player")
        {
            return;
        }
        Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 relativeForce = Vector2.Lerp(collision.transform.position - transform.position, transform.position, 0.1f);
        playerRB.AddForce(windSpeed * relativeForce * windDirection, ForceMode2D.Force);
    }
}
