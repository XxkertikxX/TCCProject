using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

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
	public Sprite Icon;
	
	public float DamageReduction() {
		return 50/(50+Defense);
	}
	
	public StatusCharacters Clone() {
        return (StatusCharacters)this.MemberwiseClone();
    }
}
