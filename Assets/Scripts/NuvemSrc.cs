using UnityEngine;

public class NuvemSrc : MonoBehaviour
{
    [SerializeField] private float LimitX = -20;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction = Vector2.left;
    private int sort;

    private void Start()
    {
       sort = Random.Range(-20, -70);
        GetComponent<SpriteRenderer>().sortingOrder = sort;
    }
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if(transform.position.x < LimitX)
        {
            Destroy(gameObject);
        }
    }
}
