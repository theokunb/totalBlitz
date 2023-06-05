using UnityEngine;

public class ConditionOnLeft : Condition
{
    private Input _input;
    private UnitMover _targetUnit;
    private float _distance;

    public ConditionOnLeft(State state, Input input, UnitMover targetUnit, float distance) : base(state)
    {
        _input = input;
        _input.Enable();
        _targetUnit = targetUnit;
        _distance = distance;
    }

    ~ConditionOnLeft()
    {
        _input.Disable();
    }

    public override bool CanTransit()
    {
        var ray1 = !Physics.Raycast(new Vector3(_targetUnit.transform.position.x - 0.5f, _targetUnit.transform.position.y, _targetUnit.transform.position.z), -_targetUnit.transform.right, _distance);
        var ray2 = !Physics.Raycast(new Vector3(_targetUnit.transform.position.x + 0.5f, _targetUnit.transform.position.y, _targetUnit.transform.position.z), -_targetUnit.transform.right, _distance);
        var ray3 = !Physics.Raycast(new Vector3(_targetUnit.transform.position.x, _targetUnit.transform.position.y, _targetUnit.transform.position.z), -_targetUnit.transform.right, _distance);
        return _input.LeftReadValue() != 0 && ray1 && ray2 && ray3;
    }
}
