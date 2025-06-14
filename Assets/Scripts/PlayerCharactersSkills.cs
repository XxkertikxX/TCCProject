using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    public void PressButtonSkill(ISkill skill) {
        skill.Skill(new StatusCharacters()); //Temp
    }
}