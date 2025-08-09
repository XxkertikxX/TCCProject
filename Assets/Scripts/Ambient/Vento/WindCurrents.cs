using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class WindCurrents : MonoBehaviour, IEnviromentProperty
{
    [Header("Wind variables")]
    [SerializeField] private Vector2 windDirection;
    [SerializeField, Range(1f,100f)] private float windForce;
    [SerializeField, Range(1, 5)] private int windResistenceMult;
    private Dictionary<GameObject, Rigidbody2D> rbCheck = new();

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D playerRB = getRB(collision.gameObject);
        playerRB.AddForce(windDirection.normalized * windForce * windResistenceMult);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D playerRB = getRB(collision.gameObject);
        StartCoroutine(ApplyEffect(playerRB));
    }
    public IEnumerator ApplyEffect(Rigidbody2D playerRB)
    {
        float timing = 1f;
        while (timing > 0f)
        {
            playerRB.velocity -= windDirection * Time.deltaTime * windForce;
            timing -= Time.deltaTime;
            yield return null;
        }
    }
    private Rigidbody2D getRB(GameObject rbGO)
    {
        if (!rbCheck.ContainsKey(rbGO))
        {
            rbCheck[rbGO] = rbGO.GetComponent<Rigidbody2D>();
        }
        return rbCheck[rbGO];
    }
}
