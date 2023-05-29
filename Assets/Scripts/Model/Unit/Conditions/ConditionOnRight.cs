public class ConditionOnRight : Condition
{

    private PlayerInput _playerInput;

    public ConditionOnRight(State state) : base(state)
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    public override bool CanTransit()
    {
        return _playerInput.Player.Right.ReadValue<float>() != 0;
        //return !Physics.Raycast(_targetUnit.transform.position + Vector3.up, _targetUnit.transform.right, _distance, 6);
    }
}
