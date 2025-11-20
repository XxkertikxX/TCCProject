using UnityEngine;
using System.Collections;

public abstract class SkillBase : ScriptableObject
{
	[SerializeField] private string name;
    [SerializeField] private int timesForInvoke;
    [SerializeField] private float timePerInvokeLine;
    [SerializeField] private TypeSkill targetType;
    [SerializeField] private int skillpower;
	[SerializeField] private Sprite spriteTypeSkill;
    [SerializeField] private Sprite[] spritesEffectsSkill;

	public string Name => name;
    public int TimesForInvoke => timesForInvoke;
    public float TimePerInvokeLine => timePerInvokeLine;
    public TypeSkill TargetType => targetType;
    public int SkillPower => skillpower;
	public Sprite SpriteTypeSkill => spriteTypeSkill;
    public Sprite[] SpritesEffectsSkill => spritesEffectsSkill;
	
    public float ManaConsume;
	public float SpeedMin;
	public float SpeedMax;
	
    public abstract void Skill(float power, AttackRhythm rhythm);
	
	public abstract string TargetsString();
}