using UnityEngine;
using UnityEngine.UI;

public class SetupBattle : MonoBehaviour
{
    [SerializeField] DialogueManager dial;
    [SerializeField] DialogueTrigger dialogo;
    [SerializeField] GameObject UI;

    void Start(){
        dial.IniciarDialogo(dialogo.linhas);
        StatesUIButton(false);
    }
    
    public void ActiveUI(){
        UI.SetActive(true);
        StatesUIButton(true);
    }

    void StatesUIButton(bool state){
        Button[] botoes = FindObjectsOfType<Button>();
        foreach (Button b in botoes) {
            b.interactable = state;
        }
    }
}
