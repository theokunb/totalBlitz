using UnityEngine;

public class ConditionOnForward : Condition
{
    private Input _input;
    private UnitMover _targetUnit;
    private float _distance;

    public ConditionOnForward(State state, Input input, UnitMover targetUnit, float distance) : base(state)
    {
        _input = input;
        _input.Enable();
        _targetUnit = targetUnit;
        _distance = distance;
    }

    ~ConditionOnForward()
    {
        _input.Disable();
    }

    public override bool CanTransit()
    {
        var ray1 = !Physics.Raycast(new Vector3(_targetUnit.transform.position.x - 0.5f, _targetUnit.transform.position.y, _targetUnit.transform.position.z), _targetUnit.transform.forward, _distance);
        var ray2 = !Physics.Raycast(new Vector3(_targetUnit.transform.position.x + 0.5f, _targetUnit.transform.position.y, _targetUnit.transform.position.z), _targetUnit.transform.forward, _distance);
        var ray3 = !Physics.Raycast(new Vector3(_targetUnit.transform.position.x, _targetUnit.transform.position.y, _targetUnit.transform.position.z), _targetUnit.transform.forward, _distance);
        return _input.ForwardReadValue() != 0 && ray1 && ray2 && ray3;
    }
}
