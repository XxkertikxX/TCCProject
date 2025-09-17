using UnityEngine;
using UnityEngine.UI;

public class SliderEffect : MonoBehaviour
{
    [SerializeField] private Texture2D pencil;
    [SerializeField] private Texture2D eraser;
    Slider sliderVolume;
    private float value;

    private void Awake()
    {
        sliderVolume = GetComponent<Slider>();   
    }

    public void SpriteApparence()
    {
        Cursor.SetCursor(WhatSprite(), new Vector2(0.04151125f, 0.04400938f), CursorMode.Auto);
    }

    private Texture2D WhatSprite()
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
    }
}
