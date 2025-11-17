using UnityEngine;

public class GroundType : MonoBehaviour
{
    [SerializeField] SoundTypes typeOfGround;
    private FootStep piso;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.tag == "Player")
        {
            piso = collision.gameObject.GetComponentInChildren<FootStep>();
            if(piso.typeOfGround != typeOfGround)
                piso.typeOfGround = typeOfGround;
                
        }
    }
}
