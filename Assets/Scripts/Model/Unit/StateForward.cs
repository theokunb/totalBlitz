public class StateForward : State
{
    private UnitMover _unit;

    public StateForward(Fsm fsm) : base(fsm)
    {
        _unit = ServiceLocator.Instance.Get<UnitMover>();
    }

    public override void Update()
    {
        base.Update();
        _unit.MoveForward();
    }
}
