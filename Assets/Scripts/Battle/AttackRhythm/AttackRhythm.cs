using System.Collections;
using UnityEngine;

public abstract class AttackRhythm : MonoBehaviour{
    public float Damage = 0;

    public abstract void Constructor(RhythmProperties);
    public abstract IEnumerator Attack(SkillBase skill);
    public abstract Update();
    public abstract FixedUpdate();
}