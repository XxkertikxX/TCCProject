using UnityEngine;

public class LineRhythm : MonoBehaviour
{
    private EmberRhythmProperties rhythmProperties;
    
    private float speed = 3f;
    
    void Start() {
        totallyLineCoord = rhythmProperties.RendTotallyLine.bounds.max.x;
        totallyLineSize = rhythmProperties.RendTotallyLine.bounds.size.x;
    }

    public float PerDamage() {
        float distance = Mathf.Abs(transform.position.x - rhythmProperties.CenterLine.position.x);
        return 1f - (distance / (totallyLineSize / 2f));
    }

    public bool DestroyLineOutLimits(float totallyLineCoord) {
        return transform.position.x > totallyLineCoord;
    }
}