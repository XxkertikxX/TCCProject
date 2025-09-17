using UnityEngine;
using UnityEngine.UI;

public class SliderEffect : MonoBehaviour
{
    [SerializeField] private Texture2D pencil;
    [SerializeField] private Texture2D eraser;
    [SerializeField] private Text[] volumeVisual;
    [SerializeField] private Slider[] sliderVolume;
    public static float volumeGeneral;
    private float value;

    private void Awake()
    {
        sliderVolume = GetComponentsInChildren<Slider>();
        volumeVisual = GetComponentsInChildren<Text>();
    }

    public void CursorSpriteApparence(int i) //arrumar volume e mouse
    {
        Texture2D mouseTex = pencil;//WhatSprite(i); tem que ver essa coisa
        Vector2 hotspot = Hotspot(mouseTex);
        Cursor.SetCursor(mouseTex, hotspot, CursorMode.Auto);
    }

    public void ChangeVolume(int i)
    {
        volumeGeneral = Mathf.Round((getValue(i) * 100));
        volumeVisual[i].text = volumeGeneral.ToString();
    }

    private Texture2D WhatSprite(int index)
    {
        Slider sliderVol = sliderVolume[index];
        value = sliderVol.value;
        if (value > sliderVol.value)
            return pencil;
        if (value < sliderVol.value)
            return eraser;
        else
            return null;
    }

    private Vector2 Hotspot(Texture tex)
    {
        Debug.Log("Porque?");
        return new Vector2(tex.width, tex.height);
    }

    private float getValue(int index)
    {
        return sliderVolume[index].value;
    }
} 
