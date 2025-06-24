using UnityEngine;

public class RhythmObj : MonoBehaviour
{
    [SerializeField] GameObject rh;
    [SerializeField] Transform center;
    [SerializeField] Renderer rend;


    public static GameObject Rhythm;
    public static Transform centerLine;
    public static Renderer rendTotallyLine;

    void Start() {
        Rhythm = rh;
        centerLine = center;
        rendTotallyLine = rend;
    }
}
