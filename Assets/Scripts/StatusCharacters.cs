using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "CharacterCreator")]
public class StatusCharacters : ScriptableObject
{
	public string Name;
    public float Level;
    public float Life;
    public float Power;
    public List<SkillBase> Skills;
}
