public class StateForward : State
{
    private UnitMover _unitMover;

    public StateForward(Fsm fsm,UnitMover mover) : base(fsm)
    {
        _unitMover = mover;
    }

    public override void Update()
    {
        base.Update();
        _unitMover.MoveForward();
    }
}
