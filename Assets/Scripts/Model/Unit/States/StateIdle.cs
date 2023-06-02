public class StateIdle : State
{
    private UnitMover _unit;

    public StateIdle(Fsm fsm, UnitMover mover) : base(fsm)
    {
        _unit = mover;
    }

    public override void Update()
    {
        base.Update();
        _unit.Stay();
    }
}
