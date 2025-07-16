using UnityEngine;

public class RhythmObj : MonoBehaviour
{
    [SerializeField] private GameObject rhythm;
    [SerializeField] private Transform centerLine;
    [SerializeField] private Renderer rendTotallyLine;


    public static GameObject Rhythm;
    public static Transform CenterLine;
    public static Renderer RendTotallyLine;

    void Start() {
        Rhythm = rhythm;
        CenterLine = centerLine;
        RendTotallyLine = rendTotallyLine;
    }
}
