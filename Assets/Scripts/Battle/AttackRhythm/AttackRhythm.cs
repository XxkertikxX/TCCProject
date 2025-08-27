using System.Collections;
using UnityEngine;

public abstract class AttackRhythm : MonoBehaviour {
    public float Damage = 0;

    public abstract void Constructor(RhythmProperties rhythmProperties);
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract IEnumerator Attack(SkillBase skill);
}