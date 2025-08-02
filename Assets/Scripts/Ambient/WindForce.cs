using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    float windSpeed = .5f;
    public Vector2 windDirection;
    public float windForce;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision == null || collision.gameObject.tag != "Player")
        {
            return;
        } Debug.Log("Esta no collider");
        Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
        playerRB.AddForce(windDirection * windForce);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == null || collision.gameObject.tag != "Player")
        {
            return;
        }Debug.Log("Saiu do collider");
        Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
        //playerRB.velocity = Vector2.zero;
    }
}
