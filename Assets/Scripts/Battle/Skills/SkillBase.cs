using UnityEngine;
using System.Collections;

public abstract class SkillBase : ScriptableObject
{
    [SerializeField] private int timesForInvoke;
    [SerializeField] private float timePerInvokeLine;
    [SerializeField] private TypeSkill targetType;
    [SerializeField] private int manaconsume;

    public int TimesForInvoke => timesForInvoke;
    public float TimePerInvokeLine => timePerInvokeLine;
    public TypeSkill TargetType => targetType;
    public int ManaConsume => manaconsume;

    public abstract IEnumerator Skill(float power, float rhythmDamage);
}