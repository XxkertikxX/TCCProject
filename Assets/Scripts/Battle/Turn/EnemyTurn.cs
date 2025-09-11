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
        enemy.Skills[randomSkill].Skill(enemy.Power, new EnemyRhythm());
        GameAudioManager.PlaySound(SoundTypes.EnemyAttack, 0.5f);
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
            character.GetComponent<CharacterAttributes>().TurnsForCanAttack -= 1;
        }
    }

    private GameObject[] Characters() {
        return GameObject.FindGameObjectsWithTag("Character");
    }
}