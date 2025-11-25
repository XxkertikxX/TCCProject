using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class GlobalLightTransition : MonoBehaviour
{
    private bool trasitioning = false;
    [SerializeField] private Light2D lightColor;
    private Color RegularColor;
    private float oldIntensity;
    [Header("Components")]
    [SerializeField] private Color NewColor;
    [Header("Values")]
    [SerializeField] private float newIntensity;
    [SerializeField] private float changeSpeed;
    

    private void Start()
    {
        lightColor = GetComponent<Light2D>();
        RegularColor = lightColor.color;
        oldIntensity = lightColor.intensity;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            if (!trasitioning)
            {
                float direcao = Mathf.Sign(collision.transform.position.x - transform.position.x);

                if (direcao < 0)
                {
                    StartCoroutine(ChangeColorAndIntesity(RegularColor, oldIntensity));
                }

                if (direcao > 0)
                {
                    StartCoroutine(ChangeColorAndIntesity(NewColor, newIntensity));
                }
            }
        }
    }

    private IEnumerator ChangeColorAndIntesity(Color colorToChange, float intensity)
    {
        trasitioning = true;
        Color c;
        float i;
        while (Vector4.Distance(lightColor.color, colorToChange) > 0.01f || Mathf.Abs(lightColor.intensity - intensity) > 0.01f)
        {
            c = Color.Lerp(lightColor.color, colorToChange, changeSpeed);
            lightColor.color = c;
            i = Mathf.Lerp(lightColor.intensity, intensity, changeSpeed);
            lightColor.intensity = i;
            yield return null;
        }
        lightColor.color = colorToChange;
        lightColor.intensity = intensity;
        trasitioning = false;
    }
}