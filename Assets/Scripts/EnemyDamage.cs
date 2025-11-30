
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    Animator eAnim;

    private void Start()
    {
        eAnim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
    }

    public void EnemyTakingDamage()
    {
        if (eAnim.GetBool("Died") != true)
        {
            eAnim.Play("TakingDamage");
        }
    }
}
