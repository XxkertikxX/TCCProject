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

    void Update() {
        if(verticalMovementCondiction.CanMove()){
            verticalMovement.MoveY();
        }
    }
}
