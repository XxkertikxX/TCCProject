using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class NoteRhythm : AttackRhythm, IUpdateRhythm 
{
    private RhythmProperties rhythmProperties;

    private int totalLines;
    private int timesForInvoke = 1;

    private List<Queue<NoteMovement>> notes = new List<Queue<NoteMovement>>();

    void Awake() {
        rhythmProperties = GetComponent<RhythmProperties>();
    }

    public void UpdateAttack() {
        Click();
        DequeueLineOutLimits();
        CloseRhythm();
        ChangeSprites();
    }

    public void FixedUpdateAttack() {
        foreach (Queue<NoteMovement> queue in notes) {
            foreach (NoteMovement note in queue) {
                Directions direction = note.Direction;
                Vector2 directionV2 = direction.Direction;
                note.Rb.Move(directionV2, direction.Speed);
            }
        }
    }

    public override IEnumerator Attack(SkillBase skill) {
        for (int i = 0; i < rhythmProperties.Index(); i++) {
            notes.Add(new Queue<NoteMovement>());
        }

        ActiveRhythm(true);

        totalLines = skill.TimesForInvoke;
        timesForInvoke = totalLines;

        while (timesForInvoke > 0) {
            yield return StartCoroutine(InvokeLine(skill));
        }

        while (!WithoutNotes()) {
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
        direction.Speed = rhythmProperties.Speed();
        Notes note = rhythmProperties.Note();
        GameObject noteGO = Instantiate(note.Note, direction.InstantiatePosition.position, Quaternion.identity);
        NoteMovement noteMovement = noteGO.AddComponent<NoteMovement>();
        noteMovement.Direction = direction;
        noteMovement.Note = note;
        notes[direction.Index].Enqueue(noteMovement);
    }

    private void Click() {
        List<string> directions = new List<string>();
        foreach (Queue<NoteMovement> queue in notes) {
            if (queue.Count > 0) {
                directions.AddRange(queue.Peek().Note.Input);
            }
        }

        bool equalsInput = directions.Count != directions.Distinct().Count();

        if (!equalsInput) {
            foreach (Queue<NoteMovement> queue in notes) {
                if (queue.Count > 0) {
                    CheckAndDequeueLine(queue.Peek());
                }
            }
            return;
        }

        CheckAndDequeueLine(FirstNote().Peek());
    }

    private void CheckAndDequeueLine(NoteMovement firstNote) {
        if (CheckInput(firstNote)) {
            DequeueLine(FirstNote());
        }
    }

    private bool CheckInput(NoteMovement firstNote) {
        foreach (string key in firstNote.Note.Input) {
            if (InputCatalyst.input.InputButtonDown(key)) {
                return true;
            }
        }
        return false;
    }
    private void DequeueLine(Queue<NoteMovement> queue) {
        var note = queue.Dequeue();
        Damage += note.PerDamage(2) / totalLines;
        Destroy(note.gameObject);
    }

    private void DequeueLineOutLimits() {
        foreach (Queue<NoteMovement> queue in notes) {
            if (queue.Count == 0) continue;
            if (queue.Peek().DestroyLineOutLimits()) {
                var note = queue.Dequeue();
                Destroy(note.gameObject);
            }
        }
    }

    private void CloseRhythm() {
        if (timesForInvoke != 0) return;
        foreach (Queue<NoteMovement> queue in notes) {
            if (queue.Count != 0) return;
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

    private void ChangeSprites() {
        foreach (Queue<NoteMovement> queue in notes) {
            if(queue.Count == 0) continue;
            Directions dir = queue.Peek().Direction;
            Notes notes = queue.Peek().Note;
            dir.SprRendCenterLine.sprite = notes.CenterLineSpr;
            Debug.Log(notes.CenterLineSpr);
        }
    }

    private Queue<NoteMovement> FirstNote() {
        Queue<NoteMovement>[] queues = notes.ToArray();
        Queue<NoteMovement> queue = new Queue<NoteMovement>();

        if (queues.Length == 1) return queues[0];

        for (int i = 0; i < queues.Length - 1; i++) {
            if (queues[i].Count == 0 && queues[i + 1].Count == 0) continue;
            if (queues[i + 1].Count == 0 || queues[i].Count == 0) {
                if (queues[i + 1].Count == 0) {
                    queue = queues[i];
                } else {
                    queue = queues[i + 1];
                }
                continue;
            }

            if (DistanceToCenter(queues[i + 1].Peek()) > DistanceToCenter(queues[i].Peek())) {
                queue = queues[i + 1];
            } else {
                queue = queues[i];
            }
        }
        return queue;
    }

    private float DistanceToCenter(NoteMovement note) {
        return note.Distance();
    }
}