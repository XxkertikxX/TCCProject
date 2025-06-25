using UnityEngine;

public class SetupBattle : MonoBehaviour
{
    [SerializeField] DialogueManager dial;
    [SerializeField] DialogueTrigger dialogo;
    [SerializeField] GameObject UI;

    void Start(){
        dial.IniciarDialogo(dialogo.linhas);
    }

    public void ActiveUI(){
        UI.SetActive(true);
    }
}
