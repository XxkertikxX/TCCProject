using UnityEngine;
using System.Collections;

public abstract class SkillBase : ScriptableObject
{
    [SerializeField] private int timesForInvoke;
    [SerializeField] private float timePerInvokeLine;
    [SerializeField] private TypeSkill targetType;
    [SerializeField] private int manaconsume;
    [SerializeField] private int skillpower;

    public int TimesForInvoke => timesForInvoke;
    public float TimePerInvokeLine => timePerInvokeLine;
    public TypeSkill TargetType => targetType;
    public int ManaConsume => manaconsume;
    public int SkillPower => skillpower;

    public abstract IEnumerator Skill(float power, AttackRhythm rhythm);
}