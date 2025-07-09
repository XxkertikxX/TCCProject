using UnityEngine;

public class RhythmObj : MonoBehaviour
{
    [SerializeField] private GameObject _rhythm;
    [SerializeField] private Transform _centerLine;
    [SerializeField] private Renderer _rendTotallyLine;


    public static GameObject Rhythm;
    public static Transform CenterLine;
    public static Renderer RendTotallyLine;

    void Start() {
        Rhythm = _rhythm;
        CenterLine = _centerLine;
        RendTotallyLine = _rendTotallyLine;
    }
}
