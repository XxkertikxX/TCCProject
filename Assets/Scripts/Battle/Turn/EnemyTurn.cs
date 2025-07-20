using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] private StatusCharacters enemy;
    [SerializeField] private string scene;

    void Update() {
        if (AllCharactersPlay()) {
            EnemyAttack();
            ResetTurn();
        }
    }
    
    void OnDestroy(){
        SceneManager.LoadScene(scene);
    }
    
    private void EnemyAttack() {
        int randomSkill = Random.Range(0, enemy.skills.Count);
        CatalystSkills.Damage = 1;
        enemy.skills[randomSkill].Skill(enemy.power);
    }

    private bool AllCharactersPlay() {
        var characters = GameObject.FindGameObjectsWithTag("Character");
        foreach (var character in characters) {
            if (!character.GetComponent<CharacterAttributes>().AttackInTheTurn) {
                return false;
            }
        }
        return true;
    }

    private void ResetTurn() {
        foreach (var character in Characters()) {
            character.GetComponent<CharacterAttributes>().AttackInTheTurn = false;
        }
    }

    private GameObject[] Characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}