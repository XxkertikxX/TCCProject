using System.Collections;
using UnityEngine;

public class ShowIsSelected : MonoBehaviour
{
    [SerializeField] private Color normalColor;
    [SerializeField] private Color selectedColor;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private float changeSpeed;
    Coroutine coroutine;
    bool targetIsNormalColor = false;
    void Start()
    {
        normalColor = render.color;
    }

    private void Update()
    {
        Debug.Log(render.color);
        if (coroutine != null)
            return;
        
        coroutine = StartCoroutine(StartColoring());
    }

    private Color target()
    {
        if (targetIsNormalColor)
        {
            targetIsNormalColor = false;
            return normalColor;
        }
        else
        {
            targetIsNormalColor = true;
            return selectedColor;
        }
    }

    private IEnumerator StartColoring()
    {
        Color c = target();
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * changeSpeed;
            render.color = Color.Lerp(render.color, c, t);
            yield return null;
        }
        Debug.Log(render.color != c);
        //render.color = c;
        coroutine = null;
    }

    private void OnDisable()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }

        if (render != null)
            render.color = normalColor;
    }
}
