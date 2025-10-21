using UnityEngine;
using System.Collections.Generic;

public class RhythmProperties : MonoBehaviour
{
    public float Speed;

    public GameObject Rhythm;
    [SerializeField] private List<Directions> directions;
    [SerializeField] private List<Notes> notes;

    public Notes Note() {
        int index = Random.Range(0, notes.Count);
        return notes[index];
    }

    public Directions Direction() {
        int index = Random.Range(0, directions.Count);
        return directions[index];
    }

    public int Index() {
        return directions.Count;
    }
}

[System.Serializable]
public class Directions {
    public CheckerPosition Checker;

    public Vector2 Direction;
    public SpriteRenderer SprRendCenterLine;
	public Transform CenterLine;
    public GameObject Point;
    public Transform InstantiatePosition;

    public List<string> Input;

    public int Index;
}

[System.Serializable]
public class Notes {
    public GameObject Note;
    public Sprite CenterLineSpr;
}