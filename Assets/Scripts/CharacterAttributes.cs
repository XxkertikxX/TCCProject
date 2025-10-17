using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    public StatusCharacters Character;
    [HideInInspector] public ResourceSystem LifeSystem;
    [HideInInspector] public AttackRhythm Rhythm;

    [HideInInspector] public int TurnsForCanAttack = 0;
	
	[HideInInspector] public Animator Anim;
	public string AnimString;
    
    void Awake() {
        Rhythm = GetComponent<AttackRhythm>();
		Anim = GetComponent<Animator>();
    }
}
