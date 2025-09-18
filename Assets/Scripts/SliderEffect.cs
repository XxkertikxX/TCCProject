using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderEffect : MonoBehaviour
{
    [Header("Class return")]
    [SerializeField] private ReturnSpriteAndHotspot[] spritesAndHotspots;

    [Header("UI")]
    [SerializeField] private Text[] volumeVisual;
    [SerializeField] private Slider[] sliderVolume;

    public static float volumeGeneral;
    public static float volumeMusic;
    private float[] frontValue = new float[2];
    private float[] backValue = new float[2];

    private void Start()
    {
        backValue[0] = frontValue[0];
        backValue[1] = frontValue[1];
    }

    private void Awake()
    {
        sliderVolume = GetComponentsInChildren<Slider>();
        volumeVisual = GetComponentsInChildren<Text>();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void CursorSpriteApparence(int i)
    {
        Texture2D mouseTex = WhatSprite(i).texture;
        Vector2 hotspot = WhatSprite(i).hotspot;
        Cursor.SetCursor(mouseTex, hotspot, CursorMode.Auto);
    }

    public void ChangeVolume()
    {
        volumeGeneral = sliderVolume[0].value;
        volumeMusic = sliderVolume[1].value;
        volumeVisual[0].text = Mathf.Round((volumeGeneral * 100)).ToString();
        volumeVisual[1].text = Mathf.Round((volumeMusic * 100)).ToString();
    }

    public void PointBackToNormal()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    private ReturnSpriteAndHotspot WhatSprite(int index)
    {
        Slider sliderVol = sliderVolume[index];
        frontValue[index] = sliderVol.value;
        if (frontValue[index] > backValue[index])
        {
            backValue[index] = sliderVol.value;
            return spritesAndHotspots[0];
        }
        if (frontValue[index] < backValue[index])
        {
            backValue[index] = sliderVol.value;
            return spritesAndHotspots[1];
        }
        return spritesAndHotspots[1];
    }
}

[Serializable]
public class ReturnSpriteAndHotspot
{
    public Texture2D texture;
    public Vector2 hotspot;
    public ReturnSpriteAndHotspot(Texture2D t, Vector2 h)
    {
        t = texture;
        h = hotspot;
    }
}
