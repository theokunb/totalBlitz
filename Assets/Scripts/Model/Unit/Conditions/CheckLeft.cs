using UnityEngine;

public class CheckLeft : Condition
{
    private UnitMover _targetUnit;
    private float _distance;

    public CheckLeft(State targetState, UnitMover targetUnit, float distance) : base(targetState)
    {
        _targetUnit = targetUnit;
        _distance = distance;
    }

    public override bool CanTransit()
    {
        return _targetUnit.HaveObstacle(-_targetUnit.transform.right / 3);
        //return Physics.Raycast(_targetUnit.transform.position, -_targetUnit.transform.right, _distance);
    }
}
