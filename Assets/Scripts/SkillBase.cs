using UnityEngine;

public abstract class SkillBase : ScriptableObject
{
    public int TimesForInvoke;

    public abstract void Skill(float power, hp target);
}