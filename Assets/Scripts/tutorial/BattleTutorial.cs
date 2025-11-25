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
        hasTutorial = false;
        foreach(var tutorial in tutoriais) {
            tutorial.SetActive(true);
            yield return new WaitForDialogKeyDown();
            tutorial.SetActive(false);
        }
    }
}
public class WaitForDialogKeyDown : CustomYieldInstruction {
    public override bool keepWaiting {
        get {
            return InputCatalyst.input.InputButtonDown("Skip");
        }
    }
}