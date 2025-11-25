using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    public StatusCharacters Character;
    [HideInInspector] public ResourceSystem LifeSystem;
    [HideInInspector] public AttackRhythm Rhythm;

    public int TurnsForCanAttack = 0;
	
	[HideInInspector] public Animator Anim;
	public string AnimString;
    public GameObject[] attackAnimations;
    public int[] multipleAttacks = {1,1};
    
    void Awake() {
        Rhythm = GetComponent<AttackRhythm>();
		Anim = GetComponentInChildren<Animator>();
    }
}
