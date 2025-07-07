using System.Collections;
using UnityEngine;

public class SystemRhythm : MonoBehaviour
{
    static public int PosSkill;
    [SerializeField] GameObject Line;
    [SerializeField] Transform InstantiatePosition;

    void OnEnable() {
        CatalystSkills.Damage = 0;
        StartCoroutine(SpawnLines());
    }

    IEnumerator SpawnLines() {
        SkillBase skill = CharStatus().skills[PosSkill];
        int TimesForInvoke = skill.TimesForInvoke;
        while (TimesForInvoke > 0) {
            var line = Instantiate(Line, InstantiatePosition.position, Quaternion.identity);
            line.GetComponent<LineRhythm>().linesMissingSpawn = TimesForInvoke;
            TimesForInvoke--;
            yield return new WaitForSeconds(skill.TimePerInvokeLine);
        }
    }

    void OnDisable() {
        UseSkill();
    }
    
    void UseSkill() {
        CharStatus().skills[PosSkill].Skill(CharStatus().power);
        character().attackInTheTurn = true;
    }
    
    StatusCharacters CharStatus(){
        return character().character;
    }
    
    CharacterStatus character(){
        return PlayerCharactersSkills.character;
    }
}