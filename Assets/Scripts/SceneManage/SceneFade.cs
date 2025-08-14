using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using System.Collections;

public class SceneFade : MonoBehaviour
{
    Image panel;
    Animator fadeAnimator;

    private void Awake()
    {
        panel = GetComponent<Image>();
        fadeAnimator = GetComponent<Animator>();
    }

    public void EnterNewScene()
    {
        fadeAnimator.SetTrigger("EnterScene");
    }

    public void ChangeScene() //mudar cena por aqui, fazer como um "gerenciador" de cenas
    {
        
    }
}
