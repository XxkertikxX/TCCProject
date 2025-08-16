using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    public StatusCharacters Character;
    public ResourceSystem LifeSystem;
    [HideInInspector] public bool AttackInTheTurn = false;
    [HideInInspector] public AttackRhythm Rhythm;

    void Awake() {
        Rhythm = GetComponent<AttackRhythm>();
    }
}
