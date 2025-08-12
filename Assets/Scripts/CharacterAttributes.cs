using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    public StatusCharacters Character;
    public LifeSystem Hp;
    [HideInInspector] public bool AttackInTheTurn = false;
    public IAttackRhythm Rhythm;
}
