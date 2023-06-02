public class StateRight : State
{
    private UnitMover _unit;

    public StateRight(Fsm fsm, UnitMover mover) : base(fsm)
    {
        _unit = mover;
    }

    public override void Update()
    {
        base.Update();
        _unit.MoveRight();
    }
}
