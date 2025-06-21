using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "CharacterCreator")]
public class StatusCharacters : ScriptableObject
{
    public int hp;
    public int damage;
    public bool AttackInTheTurn;
    public List<ISkill> skills;
}
