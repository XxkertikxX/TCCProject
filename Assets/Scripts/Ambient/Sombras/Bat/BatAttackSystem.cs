using System.Collections;
using UnityEngine;
using System;

public class BatAttackSystem : MonoBehaviour
{
    static public event Action OnBatAttack;
    static public event Action OnBatEndAttack;
    static public event Action OnBatInPlayer;
    static public event Action<Vector2> OnBatRandomMove;

    [SerializeField] private float minDecisionTime = 2f;
    [SerializeField] private float maxDecisionTime = 5f;
    [SerializeField, Range(0f, 1f)] float chaseProbability = 0.3f;

    private Transform playerTransform;
    private Collider2D triggerArea;

    private HideAbility hideAbility;

    private bool chasing = false;

    static public void ActiveOnBatInPlayerEvent() {
        OnBatInPlayer?.Invoke();
    }

    void Start() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        hideAbility = player.GetComponent<HideAbility>();
        playerTransform = player.transform;
        triggerArea = GetComponent<Collider2D>();
        StartCoroutine(BehaviorLoop());
    }

    private IEnumerator BehaviorLoop() {
        while (true) {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minDecisionTime, maxDecisionTime));
            bool playerHiding = hideAbility.Hide;
            VerifyChase(playerHiding);
            if(!chasing) {
                SetRandomTarget();
            }
        }
    }

    private void VerifyChase(bool playerHiding) {
        if (MustChase(playerHiding) && !chasing) {
            chasing = true;
            OnBatAttack?.Invoke();
        }
        else if (chasing && playerHiding) {
            chasing = false;
            OnBatEndAttack?.Invoke();
        }
    }

    private bool MustChase(bool playerHiding) {
        bool canChase = (IsPlayerInsideArea()) && !playerHiding;
        bool mustChase = UnityEngine.Random.value < chaseProbability && canChase;
        return mustChase;
    }

    private bool IsPlayerInsideArea() {
        return triggerArea.bounds.Contains(playerTransform.position);
    }
    
    private void SetRandomTarget() {
        Bounds bounds = triggerArea.bounds;
        float x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
        float y = UnityEngine.Random.Range(bounds.min.y, bounds.max.y);
        Vector2 targetPosition = new Vector2(x, y);
        OnBatRandomMove?.Invoke(targetPosition);
    }
}