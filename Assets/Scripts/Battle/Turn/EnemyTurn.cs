using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class EnemyTurn : MonoBehaviour
{
    public int Index;

    [SerializeField] private string scene;
    [SerializeField] private Event eventDialog;

    private StatusCharacters enemy;

    void Awake() {
        enemy = GetComponent<CharacterAttributes>().Character;
    }

    void Update() {
        if (AllCharactersPlay() || LowestManaConsume() > ManaSystem.Mp.ActualValue()) {
            StartCoroutine(EnemyAttack());
            ResetTurn();
        }
        if(Characters().Length == 0) {
            Save(false);
        }
    }
    
    void OnDestroy() {
        Save(true);
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
        foreach (var character in Characters()) {
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

    private void Save(bool win) {
        SaveSystem saveSystem = new SaveSystem();
        saveSystem.SaveBattle(0, win);
        GameObject.FindObjectOfType<SaveLoader>().Load();
    }
}