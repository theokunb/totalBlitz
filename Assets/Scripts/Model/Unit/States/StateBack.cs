public class StateBack : State
{
    private UnitMover _unitMover;

    public StateBack(Fsm fsm, UnitMover mover) : base(fsm)
    {
        _unitMover = mover;
    }

    public override void Update()
    {
        base.Update();
        _unitMover.MoveBack();
    }
}
