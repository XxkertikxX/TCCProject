using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] StatusCharacters Enemy;

    void Update() {
        if (AllCharactersPlay()) {
            EnemyAttack();
            ResetTurn();
        }
    }
    void EnemyAttack() {
        int randomSkill = Random.Range(0, Enemy.skills.Count);
        Enemy.skills[randomSkill].Skill();
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

    void ResetTurn(){
        var characters = GameObject.FindGameObjectsWithTag("Character");
        foreach(var character in characters) {
            character.GetComponent<CharacterStatus>().character.AttackInTheTurn = false;
        }
    }
}
