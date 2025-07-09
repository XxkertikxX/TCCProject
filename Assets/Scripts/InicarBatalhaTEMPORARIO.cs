using UnityEngine;
using UnityEngine.SceneManagement;

public class InicarBatalhaTEMPORARIO : MonoBehaviour
{
    [SerializeField] private string combatScene;
    
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(combatScene);
        }
    }
}
