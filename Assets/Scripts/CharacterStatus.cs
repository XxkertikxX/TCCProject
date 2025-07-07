using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public StatusCharacters character;
    public hp Hp;
    [HideInInspector] public bool attackInTheTurn = false;
}
