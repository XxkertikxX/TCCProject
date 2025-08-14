using UnityEngine;

public class LineRhythm : MonoBehaviour
{
    private float totallyLineCoord;
    private float totallyLineSize;
    private float speed = 3f;
    
    void Start() {
        totallyLineCoord = RhythmObj.RendTotallyLine.bounds.max.x;
        totallyLineSize = RhythmObj.RendTotallyLine.bounds.size.x;
    }

    void Update() {
        DestroyLineOutLimits();
    }

    void FixedUpdate() {
        transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
    }

    public float PerDamage() {
        float distance = Mathf.Abs(transform.position.x - RhythmObj.CenterLine.position.x);
        return 1f - (distance / (totallyLineSize / 2f));
    }

    private void DestroyLineOutLimits() {
        if(transform.position.x > totallyLineCoord){
            Destroy(gameObject);
        }
    }
}