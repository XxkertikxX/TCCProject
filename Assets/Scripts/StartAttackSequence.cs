using UnityEngine;

public class StartAttackSequence : MonoBehaviour
{
    [SerializeField] private int attackNumber;
    [SerializeField] private bool effect;
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();

        if(!effect)
            anim.SetInteger("attackN", attackNumber);
        else
            anim.SetBool("Effect",effect);
    }
}
