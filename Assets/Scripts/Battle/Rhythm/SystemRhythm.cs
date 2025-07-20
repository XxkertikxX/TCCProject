using System.Collections;
using UnityEngine;

public class SystemRhythm : MonoBehaviour
{
    static public int PosSkill;

    [SerializeField] private GameObject line;
    [SerializeField] private Transform instantiatePosition;

    void OnEnable() {
        CatalystSkills.Damage = 0;
        StartCoroutine(SpawnLines());
    }

    void OnDisable() {
        UseSkill();
    }
    
    private IEnumerator SpawnLines() {
        SkillBase skill = CharStatus().skills[PosSkill];
        int TimesForInvoke = skill.TimesForInvoke;
        
        while (TimesForInvoke > 0) {
            var line = Instantiate(this.line, instantiatePosition.position, Quaternion.identity);
            line.GetComponent<LineRhythm>().LinesMissingSpawn = TimesForInvoke;
            TimesForInvoke--;
            yield return new WaitForSeconds(skill.TimePerInvokeLine);
        }
    }
    
    private void UseSkill() {
        CharStatus().skills[PosSkill].Skill(CharStatus().power);
        Character().AttackInTheTurn = true;
    }
    
    private StatusCharacters CharStatus(){
        return Character().Character;
    }
    
    private CharacterAtributes Character(){
        return PlayerCharactersSkills.Character;
    }
}