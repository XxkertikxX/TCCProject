using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSrc : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer render;
    private bool lastDirection;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
    }
    
    public void UpdateAnimation()
    {
        anim.SetFloat("X", v().x);
        anim.SetFloat ("Y", v().y);
        render.flipX = flipped();
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
