using UnityEngine;

public class LineRhythm : MonoBehaviour
{
    float totallyLineCoord;
    float totallyLineSize;
    Transform centerLine;
    float speed = 1f;

    float damage;
    
    void Start(){
        GameObject totallyLine = GameObject.FindGameObjectWithTag("TotallyLine");
        totallyLineCoord = totallyLine.GetComponent<Renderer>().bounds.max.x;
        totallyLineSize = totallyLine.GetComponent<Renderer>().bounds.size.x;
        centerLine = GameObject.FindGameObjectWithTag("CenterLine").GetComponent<Transform>();
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
        float distance = Mathf.Abs(transform.position.x - centerLine.position.x);
        return 1f - (distance / (totallyLineSize / 2f));
    }

    void DestroyLineOutLimits(){
        if(transform.position.x > totallyLineCoord){
            damage = 0;
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        CatalystSkills.Damage += damage;
    }
}
