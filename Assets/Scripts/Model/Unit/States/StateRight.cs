public class StateRight : State
{
    private UnitMover _unit;

    public StateRight(Fsm fsm) : base(fsm)
    {
        _unit = ServiceLocator.Instance.Get<UnitMover>();
    }

    public override void Update()
    {
        base.Update();
        _unit.MoveRight();
    }
}
