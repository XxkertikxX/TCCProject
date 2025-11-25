using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    public StatusCharacters Character;
    [HideInInspector] public ResourceSystem LifeSystem;
    [HideInInspector] public AttackRhythm Rhythm;

    [HideInInspector] public int TurnsForCanAttack = 0;
	
	public Animator Anim;
	public string AnimString;
    public GameObject[] attackAnimations;
    public int[] multipleAttacks = {1,1};
    
    void Awake() {
        Rhythm = GetComponent<AttackRhythm>();
		Anim = GetComponentInChildren<Animator>();
    }
}
