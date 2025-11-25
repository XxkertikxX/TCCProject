using System.Collections;
using UnityEngine;

public class BattleTutorial : MonoBehaviour
{
    public bool hasTutorial;
    [SerializeField] private GameObject[] tutoriais;

    private void OnEnable() {
        CharacterAttack.OnCharacterPreparedAttack += ActiveTutorial;
    }

    private void OnDisable() {
        CharacterAttack.OnCharacterPreparedAttack -= ActiveTutorial;
    }

    private void ActiveTutorial() {
        if (hasTutorial) {
            StartCoroutine(Active());
        }
    }

    private IEnumerator Active() {
        foreach(var tutorial in tutoriais) {
            yield return null;
        }
    }
}
