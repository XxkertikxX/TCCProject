using UnityEngine;
using System.Collections.Generic;

public class EmberRhythmProperties : MonoBehaviour
{
    public float Speed;

    public GameObject Rhythm;
    public Transform CenterLine;
    [SerializeField] private List<Directions> directions;
    
    [SerializeField] private List<GameObject> note;
    public List<string> Input;

    public GameObject Note() {
        int index = Random.Range(0, note.Count);
        return note[index];
    }

    public Directions Direction() {
        int index = Random.Range(0, directions.Count);
        return directions[index];
    }
}

[System.Serializable]
public class Directions {
    public CheckerPosition Checker;

    public Vector2 Direction;
    public GameObject point;
    public Transform InstantiatePosition;
}
