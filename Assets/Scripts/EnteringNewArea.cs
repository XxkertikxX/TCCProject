using Codice.Client.Common.GameUI;
using System;
using UnityEditor;
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

    private void Start()
    {
        for (int i = 0; i < nameEffectScenes.Length; i++) 
        {
            if (SceneManager.GetActiveScene().name == nameEffectScenes[i].MainReignScene.name)
            {
                Debug.Log("Cena principal do reino");
                MakeNameEffect(i);
                return;
            }
        }
        nomeRegiao.color = Color.clear;
        Debug.Log("Continua��o do Reino");
    }

    private void MakeNameEffect(int SceneIndex)
    {
        nomeRegiao.font = nameEffectScenes[SceneIndex].ReignFont;
        nomeRegiao.text = nameEffectScenes[SceneIndex].ReignName;
        nomeRegiao.CrossFadeAlpha(alphaToGo, alphaTransTime, false);
    }

}


[Serializable]
public struct ScenesWithName
{
    public SceneAsset MainReignScene;
    public Font ReignFont;
    public string ReignName;
    public ScenesWithName(SceneAsset scene,Font rFont, string rName)
    {
        MainReignScene = scene;
        ReignFont = rFont;
        ReignName = rName;
    }
}
