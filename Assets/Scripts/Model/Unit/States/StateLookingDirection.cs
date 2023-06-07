public class StateLookingDirection : State
{
    private UnitMover _mover;

    public StateLookingDirection(Fsm fsm, UnitMover mover) : base(fsm)
    {
        _mover = mover;
    }

    public override void Update()
    {
        base.Update();
        _mover.Stay();
    }
}
