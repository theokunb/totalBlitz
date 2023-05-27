using UnityEngine.InputSystem;

public class StateIdle : State
{
    private Unit _unit;
    private PlayerInput _playerInput;

    public StateIdle(Fsm fsm) : base(fsm)
    {
        _unit = ServiceLocator.Instance.Get<Unit>();
        _playerInput = new PlayerInput();
    }

    public override void Enter()
    {
        _playerInput.Enable();
        _playerInput.Player.Forward.performed += OnForward;
        _playerInput.Player.Left.performed += OnLeft;
        _playerInput.Player.Back.performed += OnBack;
        _playerInput.Player.Right.performed += OnRight;
    }

    public override void Exit()
    {
        _playerInput.Disable();
        _playerInput.Player.Forward.performed -= OnForward;
        _playerInput.Player.Left.performed -= OnLeft;
        _playerInput.Player.Back.performed -= OnBack;
        _playerInput.Player.Right.performed -= OnRight;
    }

    public override void Update()
    {
        _unit.Stay();
    }

    private void OnForward(InputAction.CallbackContext context)
    {
        Fsm.SetState<StateForward>();
    }

    private void OnRight(InputAction.CallbackContext obj)
    {
        Fsm.SetState<StateRight>();
    }

    private void OnBack(InputAction.CallbackContext obj)
    {
        Fsm.SetState<StateBack>();
    }

    private void OnLeft(InputAction.CallbackContext obj)
    {
        Fsm.SetState<StateLeft>();
    }
}
