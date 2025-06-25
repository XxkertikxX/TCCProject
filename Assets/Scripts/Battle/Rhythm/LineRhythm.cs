using UnityEngine;

public class LineRhythm : MonoBehaviour
{
    public int linesMissingSpawn;

    float totallyLineCoord;
    float totallyLineSize;
    float speed = 1f;

    float damage;
    
    void Start()  {
        totallyLineCoord = RhythmObj.rendTotallyLine.bounds.max.x;
        totallyLineSize = RhythmObj.rendTotallyLine.bounds.size.x;
    }

    void Update(){
        Click();
        DestroyLineOutLimits();
    }

    void FixedUpdate(){
        transform.position += new Vector3(speed, 0, 0);
    }

    void Click(){
        if(Input.GetMouseButtonDown(0)){
            damage = PerDamage();
            Destroy(gameObject);
        }
    }

    float PerDamage(){
        float distance = Mathf.Abs(transform.position.x - RhythmObj.centerLine.position.x);
        return 1f - (distance / (totallyLineSize / 2f));
    }

    void DestroyLineOutLimits(){
        if(transform.position.x > totallyLineCoord){
            damage = 0;
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        if (linesMissingSpawn == 1) {
            RhythmObj.Rhythm.SetActive(false);
        }
        CatalystSkills.Damage += damage;
    }
}
