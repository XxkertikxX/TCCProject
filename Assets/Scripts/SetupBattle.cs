using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBattle : MonoBehaviour
{
    [SerializeField] DialogueManager dial;
    [SerializeField] DialogueTrigger dialogo;
    [SerializeField] GameObject UI;

    void Start(){
        dial.IniciarDialogo(dialogo.linhas);
    }

    void OnDisable(){
        UI.SetActive(true);
    }
}
