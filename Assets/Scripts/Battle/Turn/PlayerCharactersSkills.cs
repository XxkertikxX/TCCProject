using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    static public CharacterStatus character;

    void OnEnable() {
        TextUpdate();
    }

    public void PressButtonSkill(int posSkill) {
        SystemRhythm.PosSkill = posSkill;
        gameObject.SetActive(false);
        RhythmObj.Rhythm.SetActive(true);
    }

    void TextUpdate() {

    }
}