using UniRx;

public class GameViewModel : BaseViewModel
{
    private CompositeDisposable _disposable;
    private Timer _timer;

    public IntReactiveProperty Score;
    public FloatReactiveProperty Time;

    public GameViewModel() 
    {
        _disposable = new CompositeDisposable();
        Score = new IntReactiveProperty();
        Time = new FloatReactiveProperty();
        var unit = ServiceLocator.Instance.Get<Unit>();
        _timer = ServiceLocator.Instance.Get<Timer>();

        unit.CollectedValue.Subscribe(value => OnScoreChanged(value))
            .AddTo(_disposable);
        _timer.Seconds.Subscribe(value => OnTimeChanged(value))
            .AddTo(_disposable);
        _timer.TimeUp += OnTimerUp;
    }

    public override void Unsubscribe()
    {
        _disposable.Dispose();
        _timer.TimeUp -= OnTimerUp;
    }

    private void OnScoreChanged(int value)
    {
        Score.Value = value;
    }

    private void OnTimeChanged(float value)
    {
        Time.Value = value;
    }

    private void OnTimerUp()
    {
        _timer.enabled = false;
    }
}
