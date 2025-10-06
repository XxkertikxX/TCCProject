using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] private StatusCharacters enemy;
    [SerializeField] private string scene;
    [SerializeField] private Event eventDialog;

    void Update() {
        if (AllCharactersPlay() || LowestManaConsume() > ManaSystem.Mp.ActualValue()) {
            StartCoroutine(EnemyAttack());
            ResetTurn();
        }
    }
    
    void OnDestroy(){
        SceneManager.LoadScene(scene);
    }
    
    private IEnumerator EnemyAttack() {
        EnemyAnim.PlayTrigger("Attacked");
        int randomSkill = Random.Range(0, enemy.Skills.Count);
		var skill = enemy.Skills[randomSkill];
		yield return skill.TargetType.Targets();
        skill.Skill(enemy.Power, GetComponent<AttackRhythm>());
        GameAudioManager.PlaySound(SoundTypes.EnemyAttack);

        eventDialog.EventInvoke();
    }

    private bool AllCharactersPlay() {
        var characters = GameObject.FindGameObjectsWithTag("Character");
        foreach (var character in characters) {
            if (character.GetComponent<CharacterAttributes>().TurnsForCanAttack == 0) {
                return false;
            }
        }
        return true;
    }

    private void ResetTurn() {
        foreach (var character in Characters()) {
			var characterTurns = character.GetComponent<CharacterAttributes>();
			if(characterTurns.TurnsForCanAttack > 0) {
				characterTurns.TurnsForCanAttack -= 1;
			}
        }
		
		ManaSystem.Mp.ModifyValue(5);
    }

    private GameObject[] Characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
	
	private float LowestManaConsume() {
		List<float> manaConsume = new List<float>();
		
		foreach(var character in Characters()) {
			foreach(var skill in character.GetComponent<CharacterAttributes>().Character.Skills) {
				manaConsume.Add(skill.ManaConsume);
			}
		}
		return manaConsume.Min();
	}
}