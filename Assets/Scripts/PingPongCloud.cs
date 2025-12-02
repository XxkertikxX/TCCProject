using System.Collections;
using UnityEngine;

public class PingPongCloud : MonoBehaviour
{
    [SerializeField] private Transform[] positionGOs;
    private bool reachedPointRight = false;
    private Coroutine coroutine = null;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float waitTime = 2f;

    private bool isMoving = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = null;
        }
    }

    private void Start()
    {
        StartCoroutine(CloudLoop());
    }

    IEnumerator CloudLoop()
    {
        while (this != null)
        {
            yield return StartCoroutine(GoTo(positionGOs[1].position));

            yield return new WaitForSeconds(waitTime);

            yield return StartCoroutine(GoTo(positionGOs[0].position));

            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator GoTo(Vector2 pos)
    {
        while (Vector2.Distance(transform.position, pos) > 0.05f)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
