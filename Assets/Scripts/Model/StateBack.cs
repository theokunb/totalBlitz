public class StateBack : State
{
    private Unit _unit;
    private PlayerInput _playerInput;

    public StateBack(Fsm fsm) : base(fsm)
    {
        _unit = ServiceLocator.Instance.Get<Unit>();
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
        _unit.MoveBack();
        var moveValue = _playerInput.Player.Back.ReadValue<float>();

        if (moveValue == 0)
        {
            Fsm.SetState<StateIdle>();
        }
    }
}
