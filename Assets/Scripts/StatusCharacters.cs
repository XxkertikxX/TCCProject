using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "CharacterCreator")]
public class StatusCharacters : ScriptableObject
{
    public float hp;
    public float damage;
    public bool AttackInTheTurn;
    public List<ISkill> skills;
}
