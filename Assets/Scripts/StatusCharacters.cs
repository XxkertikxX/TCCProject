using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "CharacterCreator")]
public class StatusCharacters : ScriptableObject
{
	public string Name;
    public float Level;
	public float Xp;
    public float Life;
	public float Defense;
    public float Power;
    public List<SkillBase> Skills;
	
	public float DamageReduction() {
		return 10/(10+Defense);
	}
}
