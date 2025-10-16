using UnityEngine;

public class SpriteOrder : MonoBehaviour
{
    private SpriteRenderer PlayerRender;
    private SpriteRenderer thisRender;
    [SerializeField] Transform objectBorderRight;
    [SerializeField] Transform objectBorderLeft;
    private void Start()
    {
        thisRender = GetComponentInParent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerRender = collision.gameObject.GetComponentInChildren<SpriteRenderer>();
        }
    }

    private void LateUpdate()
    {
        if (PlayerRender == null)
            return;
        
        Transform pTransform = PlayerRender.transform;
        Vector3 directionRight = DirectionVector(pTransform.position, objectBorderRight.position);
        Vector3 directionLeft = DirectionVector(pTransform.position, objectBorderLeft.position);

        switch (directionRight.normalized.x)
        {
            case >0:
                thisRender.sortingOrder = PlayerRender.sortingOrder + 1;
            break;
            case <0:
                thisRender.sortingOrder = PlayerRender.sortingOrder - 1;
                break ;
        }
        switch (directionLeft.normalized.x)
        {
            case < 0:
                thisRender.sortingOrder = PlayerRender.sortingOrder - 1;
            break;
        }
    }

    private Vector3 DirectionVector(Vector3 pPos,Vector3 pos)
    {
        return pPos - pos;
    }
}
