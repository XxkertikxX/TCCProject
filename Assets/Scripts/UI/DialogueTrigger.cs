using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [System.Serializable]
    public class LinhaDialogo
    {
        public string nomeDoPersonagem;
        public Sprite imagemDoPersonagem;
        [TextArea] public string textoDoDialogo;
    }

    public LinhaDialogo[] linhas;
    public bool precisaInteragir = true;
    public bool soUmaVez = true;
    public GameObject promptApertarE;
    public Transform GroundCheck;
    public LayerMask camadaDoChao;

    private bool jaFalou = false;
    private bool dentroDoTrigger = false;

    void Start() {
        if (promptApertarE) {
            promptApertarE.SetActive(false);
        }
    }

    void Update() {
        if (DialogueManager.Instancia.DialogoAtivo) { return; }

        bool estaNoChao = Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.1f, camadaDoChao);

        if (precisaInteragir) {
            bool mostrarPrompt = dentroDoTrigger && estaNoChao && (!soUmaVez || !jaFalou);
            if (promptApertarE)
                promptApertarE.SetActive(mostrarPrompt);

            if (mostrarPrompt && Input.GetKeyDown(KeyCode.E))
                AcionarDialogo();
        }
        else {
            if (dentroDoTrigger && estaNoChao && (!soUmaVez || !jaFalou))
                AcionarDialogo();
        }
    }

    private void OnTriggerEnter2D(Collider2D outro) {
        if (!outro.CompareTag("Player")) { return; }
        dentroDoTrigger = true;
        if (!precisaInteragir) {
            bool estaNoChao = Physics2D.Raycast(GroundCheck.position, Vector2.down, 0.1f, camadaDoChao);
            if (estaNoChao && (!soUmaVez || !jaFalou)) {
                AcionarDialogo();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D outro) {
        if (!outro.CompareTag("Player")) { return; }
        dentroDoTrigger = false;
        if (promptApertarE)  {
            promptApertarE.SetActive(false);
        }
    }

    private void AcionarDialogo() {
        if (soUmaVez && jaFalou) { return; }
        jaFalou = true;
        if (promptApertarE) {
            promptApertarE.SetActive(false);
        }
        DialogueManager.Instancia.IniciarDialogo(linhas);
    }
}