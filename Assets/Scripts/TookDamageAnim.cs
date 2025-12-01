using UnityEngine;
using UnityEngine.UI;

public class TookDamageAnim : MonoBehaviour
{
    [SerializeField] private float charLife;
    [SerializeField] private Slider lifeSlider;
    private Animator animator;
    private void Awake()
    {
        charLife = lifeSlider.value;
        animator = GetComponent<Animator>();
    }

    public void TomouHit()
    {
        if (lifeSlider == null)
            return;

        if(lifeSlider.value < charLife && !animator.GetBool("Died"))
        {
            animator.Play("TookDamage");
        }

        charLife = lifeSlider.value;
    }
}
