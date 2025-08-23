using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharFallingPlataform : MonoBehaviour
{
    public Transform playerfront;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        OnPlataformPoint();
    }

    void OnPlataformPoint()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerfront.position, Vector2.down, 4f);
        if (hit == false)
        {
            //Animator.Play(tal);
            Debug.Log("ponta");
        }
    }
}
