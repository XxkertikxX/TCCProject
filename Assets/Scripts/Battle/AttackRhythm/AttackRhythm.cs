using System.Collections;
using UnityEngine;

public abstract class AttackRhythm : MonoBehaviour {
    public float Damage = 0;

    public abstract void UpdateAttack();
    public abstract void FixedUpdateAttack();
    public abstract IEnumerator Attack(SkillBase skill);
}