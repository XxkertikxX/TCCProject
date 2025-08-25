using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class BatAttack : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private float minWaitBeforeChaseDuration = 1f;
    [SerializeField] private float maxWaitBeforeChaseDuration = 2.5f;

    private Rigidbody2D rb;
    private Transform playerTransform;
    private Coroutine currentMovementCoroutine;
    private Vector2 origin;

    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        ConfigureRb();
        origin = rb.position;
    }

    void OnEnable() {
        BatAttackSystem.OnBatAttack += () => StartMovement(() => playerTransform.position, true);
        BatAttackSystem.OnBatEndAttack += () => StartMovement(() => origin, false);
        BatAttackSystem.OnBatRandomMove += (target) => StartMovement(() => target, false);
    }

    void OnDisable() {
        BatAttackSystem.OnBatAttack -= () => StartMovement(() => playerTransform.position, true);
        BatAttackSystem.OnBatEndAttack -= () => StartMovement(() => origin, false);
        BatAttackSystem.OnBatRandomMove -= (target) => StartMovement(() => target, false);
    }

    private void StartMovement(Func<Vector2> getTarget, bool applyRandomDelay) {
        StopCurrentMovement();
        currentMovementCoroutine = StartCoroutine(MoveToTarget(getTarget, applyRandomDelay));
    }

    private IEnumerator MoveToTarget(Func<Vector2> getTarget, bool applyRandomDelay) {
        if (applyRandomDelay) {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minWaitBeforeChaseDuration, maxWaitBeforeChaseDuration));
        }

        while (true) {
            Vector2 target = getTarget();
            if (Vector2.Distance(rb.position, target) > 0.01f) {
                rb.MovePosition(Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime));
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private void StopCurrentMovement() {
        if (currentMovementCoroutine != null) {
            StopCoroutine(currentMovementCoroutine);
            currentMovementCoroutine = null;
        }
    }

    private void ConfigureRb() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }
}