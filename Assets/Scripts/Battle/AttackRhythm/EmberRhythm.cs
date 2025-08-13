using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberRhythm : AttackRhythm
{   
    [SerializeField] private GameObject prefabRhythm;

    [SerializeField] private GameObject line;
    [SerializeField] private Transform instantiatePosition;

    [SerializeField] private List<GameObject> lines;
    
    void Update() {
        Click();
    }

    public override IEnumerator Attack(SkillBase skill) {
        int TimesForInvoke = skill.TimesForInvoke;
        
        while (TimesForInvoke > 0) {
            lines.Add(Instantiate(this.line, instantiatePosition.position, Quaternion.identity));
            TimesForInvoke--;
            yield return new WaitForSeconds(skill.TimePerInvokeLine);
        }
    }

    public override void ActiveRhythm(bool state) {
        prefabRhythm.SetActive(state);
    }

    private void Click() {
        if(Input.GetMouseButtonDown(0)){
            Destroy(gameObject);
        }
    }
}
