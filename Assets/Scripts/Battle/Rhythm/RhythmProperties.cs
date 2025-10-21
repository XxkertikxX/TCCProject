using UnityEngine;
using System.Collections.Generic;

public class RhythmProperties : MonoBehaviour
{
    [SerializeField] private float speedMin;
    [SerializeField] private float speedMax;

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

    public float Speed() {
        return Random.Range(speedMin, speedMax);
    }

    public int Index() {
        return directions.Count;
    }
}

[System.Serializable]
public class Directions {
    public float Speed;

    public CheckerPosition Checker;

    public Vector2 Direction;
    public SpriteRenderer SprRendCenterLine;
	public Transform CenterLine;
    public GameObject Point;
    public Transform InstantiatePosition;

    public int Index;
}

[System.Serializable]
public class Notes {
    public GameObject Note;
    public Sprite CenterLineSpr;
    public List<string> Input;
}