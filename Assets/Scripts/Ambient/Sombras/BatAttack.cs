using System.Collections;
using UnityEngine;

public class BatAttack : MonoBehaviour
{
    [Header("Referências")]
    public Transform player;
    public Collider2D triggerArea;
    public GameObject alertIcon;

    [Header("Movimento")]
    public float moveSpeed = 3f;
    public float chaseSpeed = 6f;
    public float stopDistance = 0.2f;

    [Header("Decisões Aleatórias")]
    public float minDecisionTime = 2f;
    public float maxDecisionTime = 5f;
    [Range(0f, 1f)]
    public float chaseProbability = 0.3f;
    public float minChaseDuration = 1f;
    public float maxChaseDuration = 2.5f;

    [Header("Opções")]
    public bool chaseOnlyIfPlayerInArea = true;

    Rigidbody2D rb;
    Vector2 targetPosition;
    bool chasing;
    float originalZ;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }
        if (player == null)
        {
            GameObject pgo = GameObject.FindWithTag("Player");
            if (pgo != null) player = pgo.transform;
        }
        if (alertIcon != null) alertIcon.SetActive(false);
        originalZ = transform.position.z;
        SetRandomTarget();
        StartCoroutine(BehaviorLoop());
    }

    void FixedUpdate()
    {
        if (chasing && chaseOnlyIfPlayerInArea && !IsPlayerInsideArea())
        {
            SetChasing(false);
            SetRandomTarget();
        }

        Vector2 current = rb.position;
        Vector2 desired = (chasing && player != null) ? (Vector2)player.position : targetPosition;
        float speed = chasing ? chaseSpeed : moveSpeed;
        Vector2 next = Vector2.MoveTowards(current, desired, speed * Time.fixedDeltaTime);
        rb.MovePosition(next);

        if (!chasing && Vector2.Distance(next, targetPosition) <= stopDistance) SetRandomTarget();
        transform.position = new Vector3(rb.position.x, rb.position.y, originalZ);
    }

    IEnumerator BehaviorLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDecisionTime, maxDecisionTime));

            bool canChase = !chaseOnlyIfPlayerInArea || IsPlayerInsideArea();
            bool willChase = Random.value < chaseProbability && canChase && player != null;

            if (willChase)
            {
                SetChasing(true);
                float dur = Random.Range(minChaseDuration, maxChaseDuration);
                float t = 0f;
                while (t < dur)
                {
                    if (chaseOnlyIfPlayerInArea && !IsPlayerInsideArea()) break;
                    t += Time.deltaTime;
                    yield return null;
                }
                SetChasing(false);
                SetRandomTarget();
            }
            else
            {
                SetChasing(false);
                SetRandomTarget();
            }
        }
    }

    bool IsPlayerInsideArea()
    {
        if (player == null || triggerArea == null) return false;
        return triggerArea.bounds.Contains(player.position);
    }

    void SetRandomTarget()
    {
        if (triggerArea == null)
        {
            targetPosition = rb.position;
            return;
        }
        Bounds b = triggerArea.bounds;
        float x = Random.Range(b.min.x, b.max.x);
        float y = Random.Range(b.min.y, b.max.y);
        targetPosition = new Vector2(x, y);
    }

    void SetChasing(bool value)
    {
        chasing = value;
        if (alertIcon != null) alertIcon.SetActive(chasing);
    }
}