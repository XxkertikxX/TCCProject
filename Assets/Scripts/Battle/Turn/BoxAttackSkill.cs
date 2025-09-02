using UnityEngine;

public class BoxAttackSkill : MonoBehaviour
{
    [SerializeField] private GameObject boxSkill;

    void OnEnable() {
        CharacterAttack.OnCharacterPreparedAttack += ActiveBox;
    }

    void OnDisable() {
        CharacterAttack.OnCharacterPreparedAttack -= ActiveBox;
    }

    private void ActiveBox() {
        boxSkill.SetActive(true);
    }
}