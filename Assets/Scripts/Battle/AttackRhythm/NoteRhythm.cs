using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteRhythm : AttackRhythm
{   
    private RhythmProperties rhythmProperties;

    private int totalLines;
    private int timesForInvoke = 1;

    private List<Queue<GameObject>> notes;
    
    void Awake() {
        rhythmProperties = GetComponent<RhythmProperties>();
    }
    
    public override void Update() {
        Click();
        DequeueLineOutLimits();
        CloseRhythm();
    }

    public override void FixedUpdate() {
        foreach(Queue<GameObject> queue in notes){
            foreach(GameObject note in queue) {
                Vector2 direction = Direction(note).Direction;
                note.GetComponent<RbMovement>().Move(direction, rhythmProperties.Speed);
            }
        }
    }

    public override IEnumerator Attack(SkillBase skill) {
        notes = new List<Queue<GameObject>>(rhythmProperties.Index());

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
        notes[direction.Index].Enqueue(note);
    }
    
    private void Click() {
        foreach(Queue<GameObject> queue in notes) {
            if(Input(queue)) {
                DequeueLine(queue);
            }
        }
    }

    private void DequeueLine(Queue<GameObject> queue) {
        if (queue.Count > 0) {
            var noteObj = queue.Dequeue();
            Damage += Note(noteObj).PerDamage(rhythmProperties.CenterLine, 2) / totalLines;
            Destroy(noteObj);
        }
    }

    private void DequeueLineOutLimits() {
        foreach(Queue<GameObject> queue in notes) {
            if(queue.Count == 0) continue;
            if(Note(queue.Peek()).DestroyLineOutLimits()) {
                var noteObj = queue.Dequeue();
                Destroy(noteObj);
            }
        }
    }

    private void CloseRhythm() {
        foreach(Queue<GameObject> queue in notes) {
            if(timesForInvoke != 0 && queue.Count != 0){
                return;
            }
        }
        ActiveRhythm(false);
    }

    private bool WithoutNotes() {
        foreach (Queue<GameObject> queue in notes) {
            if (queue.Count != 0) {
                return false;
            }
        }
        return true;
    }

    private NoteMovement Note(GameObject note) {
        return note.GetComponent<NoteMovement>();
    }

    private Directions Direction(GameObject note) {
        return Note(note).Direction;
    }

    private bool Input(Queue<GameObject> queue) {
        foreach(string key in Direction(queue.Peek()).Input) {
            if(InputCatalyst.input.InputButtonDown(key)) {
                return true;
            }
        }
        return false;
    }
}