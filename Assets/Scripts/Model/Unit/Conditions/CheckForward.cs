using UnityEngine;

public class CheckForward : Condition
{
    private UnitMover _targetUnit;
    private float _distance;

    public CheckForward(State targetState, UnitMover targetUnit, float distance) : base(targetState)
    {
        _targetUnit = targetUnit;
        _distance = distance;
    }

    public override bool CanTransit()
    {
        return _targetUnit.HaveObstacle(_targetUnit.transform.forward / 3);
        //return Physics.Raycast(_targetUnit.transform.position, _targetUnit.transform.forward, _distance);
    }
}
