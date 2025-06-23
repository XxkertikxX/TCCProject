using System.Collections;
using UnityEngine;

public class SystemRhythm : MonoBehaviour
{
    [SerializeField] GameObject Line;
    [SerializeField] Transform InstantiatePosition;
    [SerializeField] int TimesForInvoke;
    [SerializeField] float TimePerInvokeLine;
    
    void OnEnable() {
        StartCoroutine(SpawnLines());
    }

    IEnumerator SpawnLines() {
        while (TimesForInvoke > 0) {
            Instantiate(Line, InstantiatePosition.position, Quaternion.identity);
            TimesForInvoke--;
            yield return new WaitForSeconds(TimePerInvokeLine);
        }
    }
}