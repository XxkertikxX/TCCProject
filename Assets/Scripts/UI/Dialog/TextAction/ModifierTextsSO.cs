using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierTextsSO : MonoBehaviour
{
    static TextActionString textAction;
    [SerializeField] private TextsSO texts;

    void OnEnable() {
        DialogManager.OnDialogOpen += ModifySO;
    }

    void OnDisable() {
        DialogManager.OnDialogOpen -= ModifySO;
    }

    private void ModifySO() {
        texts.LineDialog[0] = textAction.TextAction();
    }
}
