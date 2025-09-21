using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSrc : MonoBehaviour
{
    private Rigidbody2D rb;
    private static Animator anim;
    private SpriteRenderer render;
    private bool lastDirection;
    private PlayerMovementJump jumpSrc;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        jumpSrc = GetComponentInParent<PlayerMovementJump>();
    }
    
    public void UpdateAnimation()
    {
        anim.SetFloat("X", Mathf.Round(v().x));
        anim.SetFloat ("Y", Mathf.Round(v().y));
        anim.SetBool("OnAir", jumpSrc._holdingJump);
        anim.SetBool("Grounded", jumpSrc.grounded());
        render.flipX = flipped();
    }

    public static void Play(string animName)
    {
        anim.Play(animName);
    }

    private Vector2 v()
    {
        return rb.velocity;
    }

    private bool flipped()
    {
        if(v().x > 0)
        {
            lastDirection = false;
            return false;
        }
        if(v().x < 0)  
        {
            lastDirection = true;
            return true;
        }
        return lastDirection;
    }
}
