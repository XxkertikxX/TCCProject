using UnityEngine;

public class RemoveAnimation : MonoBehaviour
{
    void OnDisable() {
        if (CharacterClick.CharacterAttr != null) { 
            GetComponent<Animator>().enabled = false;
        } 
    }
}
