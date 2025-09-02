using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRhythm : AttackRhythm
{   
    private RhythmProperties rhythmProperties;

    private int totalLines;
    private int timesForInvoke = 1;

    private List<Queue<NoteMovement>> notes = new List<Queue<NoteMovement>>();
    
    void Awake() {
        rhythmProperties = GetComponent<RhythmProperties>();
    }
    
    public override void UpdateAttack() {
        Click();
        DequeueLineOutLimits();
        CloseRhythm();
    }

    public override void FixedUpdateAttack() {
        foreach(Queue<NoteMovement> queue in notes){
            foreach(NoteMovement note in queue) {
                Vector2 direction = note.Direction.Direction;
                note.Rb.Move(direction, rhythmProperties.Speed);
            }
        }
    }

    public override IEnumerator Attack(SkillBase skill) {
        for(int i = 0; i < rhythmProperties.Index(); i++) {
            notes.Add(new Queue<NoteMovement>());
        }

        ActiveRhythm(true);

        totalLines = skill.TimesForInvoke;
        timesForInvoke = totalLines;
        
        while (timesForInvoke > 0) {
            yield return StartCoroutine(InvokeLine(skill));
        }

        while(!WithoutNotes()) {
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
        notes[direction.Index].Enqueue(noteMovement);
    }
    
    private void Click() {
        foreach(Queue<NoteMovement> queue in notes) {
            if(queue.Count == 0) continue;
            if(CheckInput(queue)) {
                DequeueLine(queue);
            }
        }
    }

    private void DequeueLine(Queue<NoteMovement> queue) {
        var note = queue.Dequeue();
        Damage += note.PerDamage(rhythmProperties.CenterLine, 2) / totalLines;
        Destroy(note.gameObject);
    }

    private void DequeueLineOutLimits() {
        foreach(Queue<NoteMovement> queue in notes) {
            if(queue.Count == 0) continue;
            if(queue.Peek().DestroyLineOutLimits()) {
                var note = queue.Dequeue();
                Destroy(note.gameObject);
            }
        }
    }

    private void CloseRhythm() {
        if(timesForInvoke != 0) return;
        foreach(Queue<NoteMovement> queue in notes) {
            if(queue.Count != 0) return;
        }
        ActiveRhythm(false);
    }

    private bool WithoutNotes() {
        foreach (Queue<NoteMovement> queue in notes) {
            if (queue.Count != 0) {
                return false;
            }
        }
        return true;
    }

    private bool CheckInput(Queue<NoteMovement> queue) {
        var firstNote = queue.Peek();
        foreach(string key in firstNote.Direction.Input) {
            if(InputCatalyst.input.InputButtonDown(key)) {
                return true;
            }
        }
        return false;
    }
}