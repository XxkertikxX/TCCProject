using UnityEngine;

[CreateAssetMenu(menuName ="CharacterCreator")]
public class StatusCharacters : ScriptableObject
{
    public int hp;
    public int damage;
    public bool AttackInTheTurn;
}
