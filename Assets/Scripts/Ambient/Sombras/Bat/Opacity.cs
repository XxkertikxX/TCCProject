using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Opacity : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float minAlpha = 50f / 255f;
    [SerializeField, Range(0f, 1f)]
    private float maxAlpha = 140f / 255f;
    [SerializeField, Min(0f)]
    private float speed = 1f;

    private Image img;
    private bool goingUp = true;

    void Awake()
    {
        img = GetComponent<Image>();
        if (img != null)
        {
            Color c = img.color;
            c.a = Mathf.Clamp(c.a, minAlpha, maxAlpha);
            img.color = c;
        }
    }

    void OnValidate()
    {
        minAlpha = Mathf.Clamp01(minAlpha);
        maxAlpha = Mathf.Clamp01(maxAlpha);
        if (minAlpha > maxAlpha) minAlpha = maxAlpha;
        if (speed < 0f) speed = 0f;
    }

    void Update()
    {
        if (img == null) return;

        Color c = img.color;
        float target = goingUp ? maxAlpha : minAlpha;
        c.a = Mathf.MoveTowards(c.a, target, speed * Time.deltaTime);

        if (Mathf.Approximately(c.a, target))
        {
            if (goingUp && c.a >= maxAlpha) goingUp = false;
            else if (!goingUp && c.a <= minAlpha)
            {
                goingUp = true;
                GameAudioManager.PlaySound(SoundTypes.NPC3Talking);
            }
        }

        img.color = c;
    }
}