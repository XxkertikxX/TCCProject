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
        int randomSkill = Random.Range(0, enemy.Skills.Count);
        CatalystSkills.Damage = 1;
        enemy.Skills[randomSkill].Skill(enemy.Power);
    }

    private bool AllCharactersPlay() {
        var characters = GameObject.FindGameObjectsWithTag("Character");
        foreach (var character in characters) {
            if (!character.GetComponent<CharacterStatus>().AttackInTheTurn) {
                return false;
            }
        }
        return true;
    }

    private void ResetTurn() {
        foreach (var character in characters()) {
            character.GetComponent<CharacterStatus>().AttackInTheTurn = false;
        }
    }

    private GameObject[] characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}