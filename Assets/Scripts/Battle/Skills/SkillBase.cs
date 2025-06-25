using UnityEngine;

public abstract class SkillBase : ScriptableObject
{
    public int TimesForInvoke;
    public float TimePerInvokeLine;
    
    public abstract void Skill(float power, hp target);
}