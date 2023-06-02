public class StateLeft : State
{
    private UnitMover _unit;

    public StateLeft(Fsm fsm, UnitMover mover) : base(fsm)
    {
        _unit = mover;
    }

    public override void Update()
    {
        base.Update();
        _unit.MoveLeft();
    }
}
