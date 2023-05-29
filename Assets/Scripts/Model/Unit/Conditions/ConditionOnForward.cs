public class ConditionOnForward : Condition
{
    private PlayerInput _playerInput;

    public ConditionOnForward(State state) : base(state)
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    ~ConditionOnForward()
    {
        _playerInput.Disable();
    }

    public override bool CanTransit()
    {
        return _playerInput.Player.Forward.ReadValue<float>() != 0;
        //return !Physics.Raycast(_targetUnit.transform.position + Vector3.up, _targetUnit.transform.forward, _distance, 6);
    }
}
