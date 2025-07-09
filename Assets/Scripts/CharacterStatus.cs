using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public StatusCharacters Character;
    public hp Hp;
    [HideInInspector] public bool AttackInTheTurn = false;
}
