using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRhythm : AttackRhythm
{   
    private RhythmProperties rhythmProperties;

    private int totalLines;
    private int timesForInvoke = 1;

    private Queue<GameObject> notes = new Queue<GameObject>();
    
    void Awake() {
        rhythmProperties = GetComponent<RhythmProperties>();
    }
    
    public override void Update() {
        Click();
        DequeueLineOutLimits();
        CloseRhythm();
    }

    public override void FixedUpdate() {
        foreach(GameObject note in notes) {
            Vector2 direction = Direction(note).Direction;
            note.GetComponent<RbMovement>().Move(direction, rhythmProperties.Speed);
        }
    }

    public override IEnumerator Attack(SkillBase skill) {
        ActiveRhythm(true);

        totalLines = skill.TimesForInvoke;
        timesForInvoke = totalLines;
        
        while (timesForInvoke > 0) {
            yield return StartCoroutine(InvokeLine(skill));
        }
        while(notes.Count > 0) {
            yield return null;
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
        Directions direction = rhythmProperties.Direction();
        GameObject note = Instantiate(rhythmProperties.Note(), direction.InstantiatePosition.position, Quaternion.identity);
        NoteMovement noteMovement = note.AddComponent<NoteMovement>();
        noteMovement.Direction = direction;
        notes.Enqueue(note);
    }
    
    private void Click() {
        if (notes.Count > 0) {
            if(Input()) {
                DequeueLine();
            }
        }
    }

    private void DequeueLine() {
        if (notes.Count > 0) {
            var lineObj = notes.Dequeue();
            Damage += Note(lineObj).PerDamage(rhythmProperties.CenterLine, 2) / totalLines;
            Destroy(lineObj);
        }
    }

    private void DequeueLineOutLimits() {
        if(notes.Count <= 0) return;
        if (Note(notes.Peek()).DestroyLineOutLimits()) {
            var lineObj = notes.Dequeue();
            Destroy(lineObj);
        }
    }

    private void CloseRhythm() {
        if(timesForInvoke == 0 && notes.Count == 0) {
            ActiveRhythm(false);
        }
    }

    private NoteMovement Note(GameObject note) {
        return note.GetComponent<NoteMovement>();
    }

    private Directions Direction(GameObject note) {
        return Note(note).Direction;
    }

    private bool Input() {
        foreach(string key in rhythmProperties.Input) {
            if(InputCatalyst.input.InputButtonDown(key)) {
                return true;
            }
        }
        return false;
    }
}