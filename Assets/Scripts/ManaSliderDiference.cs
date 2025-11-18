using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManaSliderDiference : MonoBehaviour
{
    [SerializeField] public static float manaCust;
    [SerializeField] private Slider backSlider;
    [SerializeField] private Slider manaSlider;
    private float actualMana;
    public barState barStates;

    public float dampRefSpeed = 0f;
    public float speed = 1f;

    private Coroutine coroutine;

    private void Start()
    {
        actualMana = manaSlider.maxValue;
        barStates = barState.stopped;
    }

    public void OnMouseEnter()
    {
        manaSlider.value -= manaCust;
    }

    public void OnMouseDown()
    {
        manaSlider.value = actualMana;
        if(manaSlider.value >= manaCust)
        {
            actualMana = manaSlider.value - manaCust;
            manaSlider.value = actualMana;
            barStates = barState.moving;
            if (coroutine == null)
                coroutine = StartCoroutine(WaitAndFall());
        }
    }

    public void OnMouseExit()
    {
        manaSlider.value = actualMana;   
    }

    IEnumerator WaitAndFall()
    {
        while(Mathf.Abs(backSlider.value - manaCust) > 0.01f)
        {
            backSlider.value = Mathf.SmoothDamp(backSlider.value, actualMana, ref dampRefSpeed, speed);
            yield return null;
        }
        backSlider.value = actualMana;
        barStates = barState.stopped;
        coroutine = null;
    }
}
public enum barState
{
    stopped,
    moving
}
