using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instancia { get; private set; }
    public GameObject telaDeDialogo;
    public GameObject telaHUD;
    public Text textoNome;
    public Text textoFala;
    public Image imagemNPC;
    public float velocidadeDivaga = 0.05f;
    public float velocidadeRapidin = 0.01f;
    [SerializeField] SetupBattle Battle = null;

    private Coroutine Divaga;
    private DialogueTrigger.LinhaDialogo[] linhas;
    private int indiceAtual;
    private float velocidadeAtual;
    private bool textoPronto;
    private PlayerMovement movimentador;

    public bool DialogoAtivo => telaDeDialogo.activeSelf;

    void Awake() {
        if (Instancia == null) Instancia = this;
        else Destroy(gameObject);
        movimentador = FindObjectOfType<PlayerMovement>();
    }

    void Start() {
        velocidadeAtual = velocidadeDivaga;
    }

    void Update() {
        //if (!telaDeDialogo.activeSelf) return;

        if (Input.GetKey(KeyCode.Space) && !textoPronto)
            velocidadeAtual = velocidadeRapidin;
        else
            velocidadeAtual = velocidadeDivaga;

        if (textoPronto && Input.GetKeyDown(KeyCode.Space))
            AvancarLinha();
    }

    public void IniciarDialogo(DialogueTrigger.LinhaDialogo[] novasLinhas) {
        //if (telaDeDialogo.activeSelf) return;
        linhas = novasLinhas;
        indiceAtual = 0;
        Time.timeScale = 0f;
        telaHUD.SetActive(false);
        telaDeDialogo.SetActive(true);
        if (movimentador != null) {
            movimentador.enabled = false;
            movimentador.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        ComecarLinha();
    }

    private void ComecarLinha() {
        textoPronto = false;
        textoNome.text = string.Empty;
        textoFala.text = string.Empty;
        imagemNPC.sprite = linhas[indiceAtual].imagemDoPersonagem;
        if (Divaga != null)
            StopCoroutine(Divaga);
        Divaga = StartCoroutine(DigitandoLinha(linhas[indiceAtual]));
    }

    private IEnumerator DigitandoLinha(DialogueTrigger.LinhaDialogo linha) {
        foreach (char c in linha.nomeDoPersonagem) {
            textoNome.text += c;
            yield return new WaitForSecondsRealtime(velocidadeAtual);
        }
        foreach (char c in linha.textoDoDialogo) {
            textoFala.text += c;
            yield return new WaitForSecondsRealtime(velocidadeAtual);
        }
        textoPronto = true;
    }

    private void AvancarLinha() {
        if (indiceAtual < linhas.Length - 1) {
            indiceAtual++;
            ComecarLinha();
        }
        else
            FecharDialogo();
    }

    private void FecharDialogo() {
        Time.timeScale = 1f;
        telaDeDialogo.SetActive(false);
        telaHUD.SetActive(true);
        if (movimentador != null)
            movimentador.enabled = true;
        if(Battle != null){
            Battle.ActiveUI();
        }
    }
}