using UnityEngine;
using System.Collections;

public class RhythmClickAnimation : MonoBehaviour
{
	[SerializeField] private int index;
	
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float glowDuration = 0.2f;
    private Color glowColor = Color.white;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void OnEnable() {
        NoteRhythm.OnClick += Brilhar;
    }

    void OnDisable() {
        NoteRhythm.OnClick -= Brilhar;
    }

    private void Brilhar(float intensity, int index) {
		if(this.index != index) return;
        StartCoroutine(GlowCoroutine(intensity));
    }

    private IEnumerator GlowCoroutine(float intensity) {
        spriteRenderer.color = glowColor * intensity;
        yield return new WaitForSeconds(glowDuration);
        spriteRenderer.color = originalColor;
    }
}