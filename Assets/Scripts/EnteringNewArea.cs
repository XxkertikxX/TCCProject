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
    [SerializeField] private float alphaTransTime;
    [SerializeField] private float alphaToGo;
    [SerializeField] private float delayTillFade;

    private void Start() {
        for (int i = 0; i < nameEffectScenes.Length; i++)  {
            if (SceneManager.GetActiveScene().name == nameEffectScenes[i].MainReignScene) {
                MakeNameEffect(i);
                return;
            }
        }
        nomeRegiao.color = Color.clear;
    }

    private void MakeNameEffect(int SceneIndex) {
        nomeRegiao.font = nameEffectScenes[SceneIndex].ReignFont;
        nomeRegiao.text = nameEffectScenes[SceneIndex].ReignName;
        StartCoroutine(AfterDelay());
    }

    IEnumerator AfterDelay() {
        yield return new WaitForSeconds(delayTillFade);
        nomeRegiao.CrossFadeAlpha(alphaToGo, alphaTransTime, false);
    }

}


[Serializable]
public struct ScenesWithName
{
    public string MainReignScene;
    public Font ReignFont;
    public string ReignName;
    public ScenesWithName(string scene,Font rFont, string rName) {
        MainReignScene = scene;
        ReignFont = rFont;
        ReignName = rName;
    }
}
