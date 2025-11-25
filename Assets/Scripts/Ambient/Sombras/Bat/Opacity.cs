using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opacity : MonoBehaviour
{
    public float minAlpha = 50f / 255f;  
    public float maxAlpha = 140f / 255f;  
    public float speed = 1f;             

    private Image img;
    private bool goingUp = true;

    void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        if (img == null) return;

        Color cor = img.color;

        if (goingUp)
        {
            cor.a += speed * Time.deltaTime;
            if (cor.a >= maxAlpha)
            {
                cor.a = maxAlpha;
                goingUp = false;
            }
        }
        else
        {
            cor.a -= speed * Time.deltaTime;
            if (cor.a <= minAlpha)
            {
                cor.a = minAlpha;
                goingUp = true;
            }
        }

        img.color = cor;
    }
}