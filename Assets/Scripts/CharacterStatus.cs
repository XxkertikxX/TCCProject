using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public StatusCharacters Character;
    public LifeSystem Hp;
    [HideInInspector] public bool AttackInTheTurn = false;
}
