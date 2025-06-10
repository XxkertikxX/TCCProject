using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    public void PressButtonSkill1(ISkills skill) {
        skill.Skill1();
    }

    public void PressButtonSkill2(ISkills skill) {
        skill.Skill2();
    }
}