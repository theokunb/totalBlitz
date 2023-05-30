public class StateLeft : State
{
    private UnitMover _unit;

    public StateLeft(Fsm fsm) : base(fsm)
    {
        _unit = ServiceLocator.Instance.Get<UnitMover>();
    }

    public override void Update()
    {
        base.Update();
        _unit.MoveLeft();
    }
}
