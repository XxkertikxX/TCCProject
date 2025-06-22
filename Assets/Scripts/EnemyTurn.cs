using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] StatusCharacters Enemy;

    void Update() {
        if (AllCharactersPlay()) {
            EnemyAttack();
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
}
