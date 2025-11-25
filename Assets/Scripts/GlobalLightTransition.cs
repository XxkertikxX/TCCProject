using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class GlobalLightTransition : MonoBehaviour
{
    private bool changeN1 = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Player"))
        {
            if (!changeN1)
            {
                StartCoroutine(ChangeColorAndIntesity(NewColor, newIntensity));
                changeN1 = true;
            }
            else
            {
                StartCoroutine(ChangeColorAndIntesity(RegularColor, oldIntensity));
                changeN1 = false;
            }
        }
    }

    private IEnumerator ChangeColorAndIntesity(Color colorToChange, float intensity)
    {
        Color c;
        float i;
        while (lightColor.color != colorToChange)
        {
            c = Color.Lerp(lightColor.color, colorToChange, changeSpeed);
            lightColor.color = c;
            yield return null;
        }

        while (lightColor.intensity != intensity)
        {
            i = Mathf.Lerp(lightColor.intensity, intensity, changeSpeed);
            lightColor.intensity = i;
            yield return null;
        }
    }
}