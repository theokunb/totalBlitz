using UnityEngine;

public class IsForwardDirection : Condition
{
    private Input _input;
    private UnitMover _mover;
    private float _distance;

    public IsForwardDirection(State state, Input input, UnitMover mover, float distance) : base(state)
    {
        _input = input;
        _input.Enable();
        _mover = mover;
        _distance = distance;
    }

    public override bool CanTransit()
    {
        var targetDirection = _input.ForwardReadValue();
        float otherDirections = Mathf.Abs(_input.BackReadValue()) + Mathf.Abs(_input.LeftReadValue()) + Mathf.Abs(_input.RightReadValue());
        var hit = _mover.HaveObstacle(_mover.transform.forward / 3);

        return targetDirection == 1 && otherDirections == 0 && hit == false;
    }
}
