public class ConditionOnIdle : Condition
{
    private PlayerInput _playerInput;

    public ConditionOnIdle(State state): base(state)
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    public override bool CanTransit()
    {
        var forward = _playerInput.Player.Forward.ReadValue<float>();
        var back = _playerInput.Player.Back.ReadValue<float>();
        var left = _playerInput.Player.Left.ReadValue<float>();
        var right = _playerInput.Player.Right.ReadValue<float>();

        return forward + back + left + right == 0;
    }
}
