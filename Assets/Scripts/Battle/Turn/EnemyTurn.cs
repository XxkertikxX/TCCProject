using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class EnemyTurn : MonoBehaviour, IDeath
{
    [SerializeField] private StatusCharacters[] characters;
    private float[] xpInicial;


	static public bool Finish;
    [SerializeField] private DialogEnableUI[] uis;
    [SerializeField] private LevelUp[] charactersLevel;
    static public float ManaAdd;
    public int Index;

    [SerializeField] private string scene;
    [SerializeField] private Event passTurn;
    [SerializeField] private Event applySkill;
    [SerializeField] private Event useSkill;
	[SerializeField] private ManaSO mana;
    [SerializeField] private GameObject Stun;

    private StatusCharacters enemy;

    private bool inAction;

    [SerializeField] private GameObject MorreuMenu;

    void Awake() {
        enemy = GetComponent<CharacterAttributes>().Character;
        xpInicial = new float[characters.Length];
        for (int i = 0; i < characters.Length; i++) {
            xpInicial[i] = characters[i].Xp;
        }
    }

    void Update() {
        if (AllCharactersPlay() || LowestManaConsume() > ManaSystem.Mp.ActualValue() && !inAction && !PlayerCharactersSkills.OnBattle) {
            StartCoroutine(Action());
        }
        if(Characters().Length == 0) {
            for (int i = 0; i < characters.Length; i++) {
                characters[i].Xp = xpInicial[i];
            }
            MorreuMenu.SetActive(true);
        }
        Stun.SetActive(GetComponent<CharacterAttributes>().TurnsForCanAttack > 0);
    }

    public void Death() {        
        if (GetComponent<CharacterAttributes>().LifeSystem.ActualValue() <= 0) {
			Finish = true;
            StartCoroutine(LevelUp());
        }
    }

    private IEnumerator LevelUp() {
        EnemyAnim.PlayBool("Died", true);
        yield return new WaitForSeconds(3f);
        foreach (var character in charactersLevel) {
            yield return character.UpLevel();
        }
        Save(true);
    }

    private IEnumerator Action() {
        if (GetComponent<CharacterAttributes>().LifeSystem.ActualValue() <= 0) yield break;
        Active(false);
        inAction = true;
		foreach (var character in Characters()) {
			var characterTurns = character.GetComponent<CharacterAttributes>();
			if(characterTurns.TurnsForCanAttack > 0) {
				characterTurns.TurnsForCanAttack -= 1;
			}
        }
		if(GetComponent<CharacterAttributes>().TurnsForCanAttack == 0) {
			yield return EnemyAttack();
		}
		GetComponent<CharacterAttributes>().TurnsForCanAttack = 0;
        Active(true);
        yield return ResetTurn();
    }

    private IEnumerator EnemyAttack() { 
        int randomSkill = Random.Range(0, enemy.Skills.Count);
		if(randomSkill == 0) {
			EnemyAnim.PlayTrigger("Attacked");
		}
		else if(randomSkill == 1) {
			EnemyAnim.PlayTrigger("Attacked2");
		}
		var skill = enemy.Skills[randomSkill];
        Texts(skill);
        CharacterClick.CharacterAttr = GetComponent<CharacterAttributes>();
        useSkill.EventInvoke();
        yield return new WaitUntil(() => DialogManager.OnDialog == false);
		yield return skill.TargetType.Targets();
        skill.Skill(enemy.Power, GetComponent<AttackRhythm>());
        applySkill.EventInvoke();
		yield return new WaitUntil(() => DialogManager.OnDialog == false);
    }

    private bool AllCharactersPlay() {
    foreach (var character in Characters()) {
        if (character.GetComponent<CharacterAttributes>().TurnsForCanAttack == 0) {
            return false;
        }
    }
    return true;

}

private IEnumerator ResetTurn() {
		ManaAdd = mana.Mana - ManaSystem.Mp.ActualValue();
		ManaSystem.Mp.ModifyValue(ManaAdd);
		passTurn.EventInvoke();
		yield return new WaitUntil(() => DialogManager.OnDialog == false);
        inAction = false;
    }

    private GameObject[] Characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
	
	public float LowestManaConsume() {
		List<float> manaConsume = new List<float>();
		
		foreach(var character in Characters()) {
			foreach(var skill in character.GetComponent<CharacterAttributes>().Character.Skills) {
                if(character.GetComponent<CharacterAttributes>().TurnsForCanAttack == 0) {
                    manaConsume.Add(skill.ManaConsume);
                }
            }
		}
		return manaConsume.Min();
	}

    public void Save(bool win) {
        SaveSystem saveSystem = new SaveSystem();
        saveSystem.SaveBattle(Index, win);
        GameObject.FindObjectOfType<SaveLoader>().Load();   
    }

    private void Texts(SkillBase skill) {
		TextBattleData.Character = enemy.Name;
		TextBattleData.SkillName = skill.Name;
	}

    private void Active(bool active) { 
        foreach(var ui in uis) {
            ui.active = active;
        }
    }
}