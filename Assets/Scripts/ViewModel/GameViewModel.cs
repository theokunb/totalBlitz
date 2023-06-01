using System;
using UniRx;

public class GameViewModel : BaseViewModel
{
    private CompositeDisposable _disposable;
    private Unit _unit;
    private Timer _timer;
    private PlayerInput _playerInput;

    public IntReactiveProperty Score;
    public FloatReactiveProperty Time;

    public event Action EndGame;

    public GameViewModel()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();

        _disposable = new CompositeDisposable();
        Score = new IntReactiveProperty();
        Time = new FloatReactiveProperty();

        _unit = ServiceLocator.Instance.Get<Unit>();
        _timer = ServiceLocator.Instance.Get<Timer>();

        _unit.CollectedValue.Subscribe(value => OnScoreChanged(value))
            .AddTo(_disposable);
        _timer.Seconds.Subscribe(value => OnTimeChanged(value))
            .AddTo(_disposable);
        _timer.TimeUp += OnTimerUp;
        _playerInput.Player.Pause.performed += OnPause;
    }

    public override void Unsubscribe()
    {
        _disposable.Dispose();
        _timer.TimeUp -= OnTimerUp;
        _playerInput.Player.Pause.performed -= OnPause;
        _playerInput.Disable();
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
        PerformResult();

        _unit.ResetCoins();
        _timer.ResetSeconds();
        EndGame?.Invoke();
        MainMenuView.Instance.gameObject.SetActive(true);
    }

    private void PerformResult()
    {
        Storage storage = ServiceLocator.Instance.Get<Storage>();

        var leaderboard = storage.Read();
        var data = new Data()
        {
            Date = DateTime.Now,
            Score = Score.Value
        };

        if (leaderboard.TryAdd(data))
        {
            storage.Write(leaderboard);
        }
    }

    private void OnPause(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        MainMenuView.Instance.gameObject.SetActive(!MainMenuView.Instance.gameObject.activeSelf);
    }
}
