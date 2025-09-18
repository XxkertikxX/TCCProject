using System;

static public class TextActionEvents {
    static public event Action OnSkillUse;
    static public event Action OnSkillApply;

    static public void SkillUseActiveEvent() {
        OnSkillUse?.Invoke();
    }

    static public void SkillApplyActiveEvent() {
        OnSkillApply?.Invoke();
    }
}
