using UnityEngine;
using System.Collections.Generic;

public class RhythmProperties : MonoBehaviour
{
    public float Speed;

    public GameObject Rhythm;
    [SerializeField] private List<Directions> directions;
    
    [SerializeField] private List<GameObject> note;

    public GameObject Note() {
        int index = Random.Range(0, note.Count);
        return note[index];
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
	public Transform CenterLine;
    public GameObject point;
    public Transform InstantiatePosition;

    public List<string> Input;

    public int Index;
}
