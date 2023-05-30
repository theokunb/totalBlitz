public class StateIdle : State
{
    private UnitMover _unit;

    public StateIdle(Fsm fsm) : base(fsm)
    {
        _unit = ServiceLocator.Instance.Get<UnitMover>();
    }

    public override void Update()
    {
        base.Update();

        _unit.Stay();
    }
}
