using UnityEngine;

public class NextAnimEvent : MonoBehaviour
{
    [SerializeField] GameObject nextAnimPoint;
    public void NextAnim(GameObject NextStepAnim)
    {
        if (nextAnimPoint != null)
        {
            Instantiate(NextStepAnim, nextAnimPoint.transform);
        }
    }
}
