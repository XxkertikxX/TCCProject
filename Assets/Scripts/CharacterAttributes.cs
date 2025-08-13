using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    public StatusCharacters Character;
    [HideInInspector] public LifeSystem Hp;
    [HideInInspector] public bool AttackInTheTurn = false;
    [HideInInspector] public AttackRhythm Rhythm;

    void Awake() {
        Hp = GetComponent<LifeSystem>();
        Rhythm = GetComponent<AttackRhythm>();
    }
}
