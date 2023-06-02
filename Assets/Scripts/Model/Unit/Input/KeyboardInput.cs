public class KeyboardInput : Input
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    public override void Enable()
    {
        _playerInput.Enable();
    }

    public override void Disable()
    {
        _playerInput.Disable();
    }

    public override float BackReadValue()
    {
        return _playerInput.Player.Back.ReadValue<float>();
    }

    public override float ForwardReadValue()
    {
        return _playerInput.Player.Forward.ReadValue<float>();
    }

    public override float LeftReadValue()
    {
        return _playerInput.Player.Left.ReadValue<float>();
    }

    public override float RightReadValue()
    {
        return _playerInput.Player.Right.ReadValue<float>();
    }
}
