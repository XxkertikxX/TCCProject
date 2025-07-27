public interface IHorizontalMovement {
    public void MoveX();
}

public interface IHorizontalMovementCondiction {
    public bool CanMove();
}

public interface IVerticalMovement {
    public void MoveY();
}

public interface IVerticalMovementCondiction {
    public bool CanMove();
}