using UnityEngine;
using System.Collections;

public class HideAbility : MonoBehaviour
{
    private Coroutine fadeRoutine;

    private bool hide = false;
    public bool Hide { get { return hide; } set { hide = value; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("HideWall")) return;
        hide = true;
        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(
            FadeTo(collision.GetComponent<SpriteRenderer>(), 0.5f, 0.1f)
        );
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("HideWall")) return;
        hide = false;
        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(
            FadeTo(collision.GetComponent<SpriteRenderer>(), 1f, 0.1f)
        );
    }
    private IEnumerator FadeTo(SpriteRenderer sprite, float targetAlpha, float duration)
    {
        float startAlpha = sprite.color.a;
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            Color c = sprite.color;
            c.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            sprite.color = c;
            yield return null;
        }
        Color finalColor = sprite.color;
        finalColor.a = targetAlpha;
        sprite.color = finalColor;
    }
}