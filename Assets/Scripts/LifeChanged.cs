using UnityEngine;
using UnityEngine.UI;

public class LifeChanged : MonoBehaviour
{
    [SerializeField] private float charLife;
    [SerializeField] private StatusCharacters lifeStat;
    [SerializeField] private Slider lifeSlider;
    private Animator animator;
    [SerializeField] private ParticleSystem healParticle;
    [SerializeField] private int numberOfParticles;
    private void Start()
    {
        animator = GetComponent<Animator>();
        healParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Awake()
    {
        charLife = lifeStat.Life;
    }

    public void VidaMudou()
    {
        if (lifeSlider == null)
            return;

        if(lifeSlider.value < charLife && !animator.GetBool("Died"))
        {
            animator.Play("TookDamage");
        }
        if(lifeSlider.value > charLife)
        {
            healParticle.Play();
        }

        charLife = lifeSlider.value ;
    }
}
