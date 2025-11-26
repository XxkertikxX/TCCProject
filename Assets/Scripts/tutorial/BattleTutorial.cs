using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleTutorial : MonoBehaviour
{
    public bool hasTutorial;
    [SerializeField] private GameObject[] tutoriais;
    [SerializeField] private SelectWithKeyboard[] keyboard;
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
        StatesUIButton(false);
        StatesKeyboardSelect(false);
        foreach (var tutorial in tutoriais) {
            tutorial.SetActive(true);
            yield return new WaitForDialogKeyDown();
            yield return null;
            tutorial.SetActive(false);
        }
        StatesUIButton(true);
        StatesKeyboardSelect(true);
    }

    private void StatesUIButton(bool state) {
        foreach (var b in FindObjectsOfType<Button>()) {
            if (b != null)
                b.interactable = state;
        }
    }

    private void StatesKeyboardSelect(bool state) {
        foreach (var key in keyboard) {
            key.enabled = state;
        }
    }
}
public class WaitForDialogKeyDown : CustomYieldInstruction {
    public override bool keepWaiting {
        get {
            return !InputCatalyst.input.InputButtonDown("Skip");
        }
    }
}