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
    public static AnimationSrc instance;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        jumpSrc = GetComponentInParent<PlayerMovementJump>();
        instance = this;
    }

    private void Update()
    {
        UpdateAnimation();
    }

    public void UpdateAnimation() //posso tentar fazer a animação mudar de velocidade de acordo com uma força opressora ou algo similar, etc
    {
        anim.SetFloat("Direction", Mathf.Round(v().normalized.x));
        anim.SetFloat ("Velocity", Mathf.Round(v().x));
        anim.SetBool("Grounded", jumpSrc.grounded());
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
