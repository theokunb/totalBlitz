using UnityEngine;

public class IsRightDirection : Condition
{
    private Input _input;
    private UnitMover _mover;
    private float _distance;

    public IsRightDirection(State state, Input input, UnitMover mover, float distance) : base(state)
    {
        _input = input;
        _input.Enable();
        _mover = mover;
        _distance = distance;
    }

    public override bool CanTransit()
    {
        var targetDirection = _input.RightReadValue();
        float otherDirections = Mathf.Abs(_input.BackReadValue()) + Mathf.Abs(_input.ForwardReadValue()) + Mathf.Abs(_input.LeftReadValue());
        var hit = _mover.HaveObstacle(_mover.transform.right / 3);

        return targetDirection == 1 && otherDirections == 0 && hit == false;
    }
}
