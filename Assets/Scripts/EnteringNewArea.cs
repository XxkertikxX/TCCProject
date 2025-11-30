using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnteringNewArea : MonoBehaviour
{
    [Header("Cena e detalhes")]
    [SerializeField] private ScenesWithName[] nameEffectScenes;

    [Header("Propriedades de efeito")]
    [SerializeField] private Text nomeRegiao;
    [SerializeField] private Text reinoDescricao;
    [SerializeField] private float alphaTransTime;
    [SerializeField] private float alphaToGo;
    [SerializeField] private float delayTillFade;
    private bool isAlreadyDisplaying = false;
    private Coroutine playingCoroutine = null;

    private void Start() {
        for (int i = 0; i < nameEffectScenes.Length; i++)  {
            if (SceneManager.GetActiveScene().name == nameEffectScenes[i].MainReignScene) {
                isAlreadyDisplaying = true;
                MakeNameEffect(i);
                return;
            }
        }
        nomeRegiao.color = Color.clear;
        reinoDescricao.color = Color.clear;
    }

    private void MakeNameEffect(int SceneIndex) {
        nomeRegiao.font = nameEffectScenes[SceneIndex].ReignFont;
        nomeRegiao.text = nameEffectScenes[SceneIndex].ReignName;
        reinoDescricao.font = nameEffectScenes[SceneIndex].ReignFont;
        reinoDescricao.text = nameEffectScenes[SceneIndex].ReignDescription;
        playingCoroutine =  StartCoroutine(AfterDelay(nomeRegiao.text, reinoDescricao.text));
    }

    IEnumerator AfterDelay(string nome, string descricao) {
        isAlreadyDisplaying = true;

        nomeRegiao.text = nome;
        reinoDescricao.text = descricao;
        nomeRegiao.CrossFadeAlpha(1f, 0f, false);
        yield return new WaitForSeconds(0.2f);
        reinoDescricao.CrossFadeAlpha(1f, 0.5f, false);
        yield return new WaitForSeconds(delayTillFade);
        nomeRegiao.CrossFadeAlpha(alphaToGo, alphaTransTime, false);
        yield return new WaitForSeconds(0.2f);
        reinoDescricao.CrossFadeAlpha(alphaToGo, alphaTransTime, false);
        while(Mathf.Abs(reinoDescricao.color.a - alphaToGo) > 0.01f)
            yield return null;
        isAlreadyDisplaying = false;
    }
}


[Serializable]
public struct ScenesWithName
{
    public string MainReignScene;
    public Font ReignFont;
    public string ReignName;
    [TextArea] public string ReignDescription;
    public ScenesWithName(string scene,Font rFont, string rName, string des) {
        MainReignScene = scene;
        ReignFont = rFont;
        ReignName = rName;
        ReignDescription = des;
    }
}
