using UnityEngine;

public class GeralCondictionMoveX : MonoBehaviour, IHorizontalMovementCondiction
{
    public bool CanMove() {
        return true;
    }
}
