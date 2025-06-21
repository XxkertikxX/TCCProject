using System.Collections.Generic;
using UnityEngine;

public class PlayerCharactersSkills : MonoBehaviour
{
    public List<ISkill> skills;
    public void PressButtonSkill(int PosSkill) {
        skills[PosSkill].Skill();
    }
}