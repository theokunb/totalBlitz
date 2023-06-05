using UnityEngine;

public class ConditionMoveRight : Condition
{
    private UnitMover _targetUnit;
    private float _distance;

    public ConditionMoveRight(State targetState, UnitMover targetUnit, float distance) : base(targetState)
    {
        _targetUnit = targetUnit;
        _distance = distance;
    }

    public override bool CanTransit()
    {
        return Physics.Raycast(_targetUnit.transform.position, _targetUnit.transform.right, _distance);
    }
}
