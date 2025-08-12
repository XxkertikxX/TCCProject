using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberRhythm : MonoBehaviour, IAttackRhythm
{    
    [SerializeField] private GameObject line;
    [SerializeField] private Transform instantiatePosition;
    
    public IEnumerator Attack(SkillBase skill) {
        int TimesForInvoke = skill.TimesForInvoke;
        
        while (TimesForInvoke > 0) {
            var line = Instantiate(this.line, instantiatePosition.position, Quaternion.identity);
            line.GetComponent<LineRhythm>().LinesMissingSpawn = TimesForInvoke;
            TimesForInvoke--;
            yield return new WaitForSeconds(skill.TimePerInvokeLine);
        }
    }
}
