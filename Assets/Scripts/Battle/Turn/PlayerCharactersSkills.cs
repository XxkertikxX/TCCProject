using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    static public CharacterAttributes Character;

    void OnEnable() {
        TextUpdate();
    }

    public void PressButtonSkill(int posSkill) {
        SystemRhythm.PosSkill = posSkill;
        gameObject.SetActive(false);
        RhythmObj.Rhythm.SetActive(true);
    }

    private void TextUpdate() {

    }
}