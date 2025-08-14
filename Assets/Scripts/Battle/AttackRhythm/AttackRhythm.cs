using System.Collections;
using UnityEngine;

public abstract class AttackRhythm : MonoBehaviour{
    public float Damage = 0;

    public abstract IEnumerator Attack(SkillBase skill);
}