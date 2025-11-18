using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteFadeInFadeOut : MonoBehaviour
{
    private SpriteRenderer spr;
    private float fadeDuration = 0.4f;
    private bool destroy = false;

    void Awake() {
        spr = GetComponent<SpriteRenderer>();
    }

    public void FadeIn() {
        StartCoroutine(Fade(0f, 1f, false));
    }

    public void FadeOut() {
        StartCoroutine(Fade(1f, 0f, true));
    }

    public bool DestroyObject() {
        return destroy;
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, bool destroy) {
        float elapsed = 0f;
        Color c = spr.color;

        while (elapsed < fadeDuration) {
            elapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            spr.color = new Color(c.r, c.g, c.b, newAlpha);
            yield return null;
        }
        this.destroy = destroy;
    }
}
