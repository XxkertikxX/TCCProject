using UnityEngine;

public class DialogStartSkillUse : DialogStartBase {
    void OnEnable() {
        TextActionEvents.OnSkillUse += StartDialog;
    }

    void OnDisable() {
        TextActionEvents.OnSkillUse -= StartDialog;
    }
}
