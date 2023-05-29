public class ConditionOnBack : Condition
{
    private PlayerInput _playerInput;

    public ConditionOnBack(State state) : base(state)
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    public override bool CanTransit()
    {
        return _playerInput.Player.Back.ReadValue<float>() != 0;
        //return !Physics.Raycast(_targetUnit.transform.position + Vector3.up, -_targetUnit.transform.forward, _distance, 6);
    }
}
