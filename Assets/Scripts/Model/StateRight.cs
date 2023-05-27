public class StateRight : State
{
    private UnitMover _unit;
    private PlayerInput _playerInput;

    public StateRight(Fsm fsm) : base(fsm)
    {
        _unit = ServiceLocator.Instance.Get<UnitMover>();
        _playerInput = new PlayerInput();
    }

    public override void Enter()
    {
        _playerInput.Enable();
    }

    public override void Exit()
    {
        _playerInput.Disable();
    }

    public override void Update()
    {
        _unit.MoveRight();
        var moveValue = _playerInput.Player.Right.ReadValue<float>();

        if (moveValue == 0)
        {
            Fsm.SetState<StateIdle>();
        }
    }
}
