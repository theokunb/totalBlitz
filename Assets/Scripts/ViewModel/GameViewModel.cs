using UniRx;

public class GameViewModel : BaseViewModel
{
    private CompositeDisposable _disposable;

    public IntReactiveProperty Score { get;private set; }

    public GameViewModel() 
    {
        _disposable = new CompositeDisposable();
        Score = new IntReactiveProperty();
        var unit = ServiceLocator.Instance.Get<Unit>();

        unit.CollectedValue.Subscribe(value => OnValueChanged(value))
            .AddTo(_disposable);
    }

    public override void Unsubscribe()
    {
        _disposable.Dispose();
    }

    private void OnValueChanged(int value)
    {
        Score.Value = value;
    }
}
