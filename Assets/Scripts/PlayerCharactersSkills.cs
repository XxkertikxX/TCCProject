using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    public void PressButtonSkill1(ISkills skill) {
        skill.Skill1(new StatusCharacters()); //Temp
    }

    public void PressButtonSkill2(ISkills skill) {
        skill.Skill2(new StatusCharacters());
    }

    ISkills character() {
        return null;
    }
}