using UnityEngine;
using System.Collections;
using Unity.VisualScripting.YamlDotNet.Core;

public class RhythmClickAnimation : MonoBehaviour
{
	[SerializeField] private int index;
	
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private float glowDuration = 0.1f;
	private Color greenStrong = new Color(0f, 1f, 0f, 1f);
	private Color greenSoft   = new Color(0.4f, 1f, 0.4f, 1f);
    private ParticleSystem particles;
    private ParticleSystem.MainModule module;
    
	void Awake() {
        particles = transform.root.GetComponentInChildren<ParticleSystem>();
        module = particles.main;
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

        GameAudioManager.PlaySound(SoundTypes.ClementineNotasAtaque);
		if(this.index != index) return;
		if(intensity > 0.95f) {
            module.startColor = greenStrong;
            particles.Emit(3);
			StartCoroutine(GlowCoroutine(greenStrong));
			return;
		}
		if(intensity > 0.85f) {
            module.startColor = greenSoft;
            particles.Emit(3);
            StartCoroutine(GlowCoroutine(greenSoft));
			return;
		}
		if(intensity > 0.65f) {
            module.startColor = Color.yellow;
            particles.Emit(3);
            StartCoroutine(GlowCoroutine(Color.yellow));
			return;
		}
		StartCoroutine(GlowCoroutine(Color.red));
    }

    private IEnumerator GlowCoroutine(Color newColor) {
        spriteRenderer.color = newColor;
        yield return new WaitForSeconds(glowDuration);
        spriteRenderer.color = originalColor;
    }
}