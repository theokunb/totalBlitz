public class ConditionOnLeft : Condition
{
    private PlayerInput _playerInput;

    public ConditionOnLeft(State state) : base(state)
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    public override bool CanTransit()
    {
        return _playerInput.Player.Left.ReadValue<float>() != 0;
        //return !Physics.Raycast(_targetUnit.transform.position + Vector3.up, -_targetUnit.transform.right, _distance, 6);
    }
}
