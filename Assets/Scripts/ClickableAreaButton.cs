using UnityEngine.UI;
using UnityEngine;

public class ClickableAreaButton : MonoBehaviour
{
    [SerializeField] private float alphaThreshold = 0.1f;
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alphaThreshold;
    }
}
