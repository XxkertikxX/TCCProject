using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    static public CharacterStatus Character;

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