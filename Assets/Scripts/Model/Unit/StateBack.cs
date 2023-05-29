public class StateBack : State
{
    private UnitMover _unit;

    public StateBack(Fsm fsm) : base(fsm)
    {
        _unit = ServiceLocator.Instance.Get<UnitMover>();
    }

    public override void Update()
    {
        base.Update();

        _unit.MoveBack();
    }
}
