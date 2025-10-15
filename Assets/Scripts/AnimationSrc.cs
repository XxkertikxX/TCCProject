using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSrc : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer render;
    private bool lastDirection;
    private PlayerMovementJump jumpSrc;
    private PlayerMovementWalk walkSrc;
    public static AnimationSrc instance;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        jumpSrc = GetComponentInParent<PlayerMovementJump>();
        walkSrc = GetComponentInParent<PlayerMovementWalk>();
        instance = this;
    }

    private void Update()
    {
        UpdateAnimation();
    }

    public void UpdateAnimation() //posso tentar fazer a animação mudar de velocidade de acordo com uma força opressora ou algo similar, etc
    {
        anim.SetFloat("Direction", (int)Mathf.Round(v().normalized.x));
        anim.SetFloat ("Velocity", Mathf.Round(v().x));
        anim.SetBool("Grounded", jumpSrc.grounded());
        anim.SetBool("Running", walkSrc._running);
        render.flipX = flipped();
    }

    private Vector2 v()
    {
        return rb.velocity;
    }

    private bool flipped()
    {
        if (v().normalized.x > 0)
        {
            lastDirection = false;
            return false;
        }
        if (v().normalized.x < 0)
        {
            lastDirection = true;
            return true;
        }
        return lastDirection;
    }
}
