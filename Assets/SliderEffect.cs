using UnityEngine;
using UnityEngine.UI;

public class SliderEffect : MonoBehaviour
{
    [SerializeField] private Texture2D pencil;
    [SerializeField] private Texture2D eraser;
    [SerializeField] private Text[] volumeVisual;
    [SerializeField] private Slider[] sliderVolume;
    private float value;
    private volumeSlider vSlide;

    private void Awake()
    {
        sliderVolume = GetComponentsInChildren<Slider>();   
    }

    public void CursorSpriteApparence() //arrumar volume e mouse
    {
        Cursor.SetCursor(null, new Vector2(0.04151125f, 0.04400938f), CursorMode.Auto);
    }

    public void ChangeVolume()
    {
        //volumeVisual.text = Mathf.Round((0.5f * 100)).ToString();
    }

    /*private Texture2D WhatSprite()
    {
        value = sliderVolume.value;
        if (sliderVolume.onValueChanged != null)
        {
            if (value > sliderVolume.value)
                return pencil;
            if (value < sliderVolume.value)
                return eraser;
            else  
                return null;
        }
        else
            return null;
    }*/
    private float getSliderValue(volumeSlider slider)
    {
        if (vSlide == volumeSlider.geral)
        {
            return sliderVolume[0].value;
        }
        if(vSlide == volumeSlider.musica)
        {
            return sliderVolume[1].value;
        }
        return 0;
    }
}
public enum volumeSlider 
{
    geral,
    musica
}
