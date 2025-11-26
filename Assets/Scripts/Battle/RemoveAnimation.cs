using UnityEngine;
using System.Collections;

public class RemoveAnimation : MonoBehaviour
{
    void OnDisable() {
        if (CharacterClick.CharacterAttr != null) {
            StartCoroutine(dis());
        } 
    }

    private IEnumerator dis() {
        yield return new WaitForSeconds(1.5f);
        GetComponent<Animator>().enabled = false;
    }
}
