using UnityEngine;

public class DialogStartSkillApply : DialogStartBase {
    void OnEnable() {
        TextActionEvents.OnSkillApply += StartDialog;
    }

    void OnDisable() {
        TextActionEvents.OnSkillApply -= StartDialog;
    }
}
