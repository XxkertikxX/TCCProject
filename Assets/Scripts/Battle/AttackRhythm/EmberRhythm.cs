using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberRhythm : AttackRhythm
{   
    private EmberRhythmProperties rhythmProperties;

    private int totalLines;
    private int timesForInvoke = 1;

    private Queue<GameObject> lines = new Queue<GameObject>();
    
    void Awake() {
        rhythmProperties = GetComponent<EmberRhythmProperties>();
    }
    
    void Update() {
        Click();
        DequeueLineOutLimits();
        CloseRhythm();
    }

    public override IEnumerator Attack(SkillBase skill) {
        ActiveRhythm(true);

        totalLines = skill.TimesForInvoke;
        timesForInvoke = totalLines;
        
        while (timesForInvoke > 0) {
            yield return StartCoroutine(InvokeLine(skill));
        }
    }


    private void ActiveRhythm(bool state) {
        rhythmProperties.Rhythm.SetActive(state);
    }

    private IEnumerator InvokeLine(SkillBase skill) {
        CreateLine();
        timesForInvoke--;
        yield return new WaitForSeconds(skill.TimePerInvokeLine);
    }

    private void CreateLine() {
        GameObject line = Instantiate(rhythmProperties.Line, rhythmProperties.InstantiatePosition.position, Quaternion.identity);
        LineRhythm lineRhythm = line.AddComponent<LineRhythm>();
        lineRhythm.Constructor(rhythmProperties);
        lines.Enqueue(line);
    }
    
    private void Click() {
        if (lines.Count > 0) {
            if(Input.GetMouseButtonDown(0)) {
                DequeueLine();
            }
        }
    }

    private void DequeueLine() {
        if (lines.Count > 0) {
            var lineObj = lines.Dequeue();
            Damage += lineObj.GetComponent<LineRhythm>().PerDamage() / totalLines;
            Destroy(lineObj);
        }
    }

    private void DequeueLineOutLimits() {
        if(lines.Peek().GetComponent<LineRhythm>().DestroyLineOutLimits()) {
            var lineObj = lines.Dequeue();
            Destroy(lineObj);
        }
    }

    private void CloseRhythm() {
        if(timesForInvoke == 0 && lines.Count == 0) {
            ActiveRhythm(false);
        }
    }
}