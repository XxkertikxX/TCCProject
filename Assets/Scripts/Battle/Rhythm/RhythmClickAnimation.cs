using UnityEngine;

public class RhythmClickAnimation : MonoBehaviour
{
    void OnEnable() {
        NoteRhythm.OnClick += Brilhar;
    }

    void OnDisable() {
        NoteRhythm.OnClick -= Brilhar;
    }

    private void Brilhar() {

    }
}
