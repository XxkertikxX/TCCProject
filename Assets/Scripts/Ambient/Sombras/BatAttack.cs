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
        bool playerHiding = IsPlayerHiding();

        if (chasing && ((chaseOnlyIfPlayerInArea && !IsPlayerInsideArea()) || playerHiding))
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

            bool playerHiding = IsPlayerHiding();
            bool canChase = (!chaseOnlyIfPlayerInArea || IsPlayerInsideArea()) && !playerHiding;
            bool willChase = Random.value < chaseProbability && canChase && player != null;

            if (willChase)
            {
                SetChasing(true);
                float dur = Random.Range(minChaseDuration, maxChaseDuration);
                float t = 0f;
                while (t < dur)
                {
                    if (chaseOnlyIfPlayerInArea && !IsPlayerInsideArea()) break;
                    if (IsPlayerHiding()) break;
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

    bool IsPlayerHiding()
    {
        if (player == null) return false;

        var monos = player.GetComponents<MonoBehaviour>();
        foreach (var m in monos)
        {
            var prop = m.GetType().GetProperty("Hide");
            if (prop != null && prop.PropertyType == typeof(bool))
            {
                object val = prop.GetValue(m, null);
                if (val is bool b && b) return true;
            }
        }

        Collider2D[] hits = Physics2D.OverlapPointAll((Vector2)player.position);
        foreach (var c in hits)
        {
            if (c != null && c.CompareTag("HideWall")) return true;
        }

        return false;
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