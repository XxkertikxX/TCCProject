using System.Collections;
using UnityEngine;

public class ShowIsSelected : MonoBehaviour
{
    [SerializeField] private Color normalColor;
    [SerializeField] private Color selectedColor;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private float changeSpeed;
    Coroutine coroutine;
    bool targetIsNormalColor = true;
    void Start()
    {
        normalColor = render.color;
    }

    private void Update()
    {
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
        while (render.color != c)
        {
            render.color = Color.Lerp(render.color, c, changeSpeed);
            yield return null;
        }

        coroutine = null;
    }

    private void OnDisable()
    {
        coroutine = null;
        render.color = normalColor;
    }
}
