using UnityEngine;

public class ConditionMoveLeft : Condition
{
    private UnitMover _targetUnit;
    private float _distance;

    public ConditionMoveLeft(State targetState, UnitMover targetUnit, float distance) : base(targetState)
    {
        _targetUnit = targetUnit;
        _distance = distance;
    }

    public override bool CanTransit()
    {
        return !Physics.Raycast(_targetUnit.transform.position, -_targetUnit.transform.right, _distance);
    }
}
