using UnityEngine;

public abstract class SkillBase : ScriptableObject
{
    [SerializeField] private int _timesForInvoke;
    [SerializeField] private float _timePerInvokeLine;
    [SerializeField] private TypeSkill _targetType;

    public int TimesForInvoke => _timesForInvoke;
    public float TimePerInvokeLine => TimePerInvokeLine;
    public TypeSkill TargetType => _targetType;

    public abstract void Skill(float power);
}