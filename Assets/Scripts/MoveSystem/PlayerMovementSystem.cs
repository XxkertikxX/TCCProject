using UnityEngine;
using System;

public class PlayerMovementSystem : MonoBehaviour
{
    static public event Action OnDisablePlayerMovementSystem; 

    private IHorizontalMovement horizontalMovement;
    private IHorizontalMovementCondiction horizontalMovementCondiction;

    private IVerticalMovement verticalMovement;
    public IVerticalMovementCondiction verticalMovementCondiction;

    void OnDisable() {
        OnDisablePlayerMovementSystem?.Invoke();
    }

    void Awake() {
        horizontalMovement = GetComponent<IHorizontalMovement>();
        horizontalMovementCondiction = GetComponent<IHorizontalMovementCondiction>();

        verticalMovement = GetComponent<IVerticalMovement>();
        verticalMovementCondiction = GetComponent<IVerticalMovementCondiction>();
    }

    void FixedUpdate() {
        if(horizontalMovementCondiction.CanMove()){
            horizontalMovement.MoveX();
        }
    }

/*************  ✨ Windsurf Command ⭐  *************/
        /// <summary>
        /// Update is called every frame, if the condiction of vertical movement is true, the vertical movement is called.
        /// </summary>
/*******  1c4787c7-a03f-4ef2-8ef7-c52151383e0d  *******/
    void Update() {
        if(verticalMovementCondiction.CanMove()){
            verticalMovement.MoveY();
        }
    }
}
