using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] StatusCharacters Enemy;
    [SerializeField] string Scene;

    void Update() {
        if (AllCharactersPlay()) {
            EnemyAttack();
            ResetTurn();
        }
    }
    void EnemyAttack() {
        int randomSkill = Random.Range(0, Enemy.skills.Count);
        CatalystSkills.Damage = 1;
        Enemy.skills[randomSkill].Skill(Enemy.damage, RandomTarget());
    }

    bool AllCharactersPlay() {
        var characters = GameObject.FindGameObjectsWithTag("Character");
        foreach (var character in characters) {
            if (!character.GetComponent<CharacterStatus>().character.AttackInTheTurn) {
                return false;
            }
        }
        return true;
    }

    void ResetTurn() {
        foreach (var character in characters()) {
            character.GetComponent<CharacterStatus>().character.AttackInTheTurn = false;
        }
    }

    hp RandomTarget() {
        int Target = Random.Range(0, characters().Length);
        return characters()[Target].GetComponent<hp>();
    }

    GameObject[] characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }

    void OnDestroy(){
        SceneManager.LoadScene(Scene);
    }
}