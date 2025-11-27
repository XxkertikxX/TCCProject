using UnityEngine;

public class NextAnimEvent : MonoBehaviour
{
    [SerializeField] GameObject nextAnimPoint;
    public void NextAnim(GameObject NextStepAnim)
    {
        Instantiate(NextStepAnim, nextAnimPoint.transform);
    }
}
