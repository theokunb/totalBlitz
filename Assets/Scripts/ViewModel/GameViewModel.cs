using System;
using UniRx;
using UnityEngine;

public class GameViewModel : BaseViewModel
{
    private CompositeDisposable _disposable;
    private Unit _unit;
    private Timer _timer;

    public IntReactiveProperty Score;
    public FloatReactiveProperty Time;

    public GameViewModel() 
    {
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
        DisableServices();
        PerformResult();

        GameMenu gameMenu = ServiceLocator.Instance.Get<GameMenu>();
        gameMenu.gameObject.SetActive(true);
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

    private void DisableServices()
    {
        UnitMover mover = ServiceLocator.Instance.Get<UnitMover>();
        CameraRotate cameraRotate = ServiceLocator.Instance.Get<CameraRotate>();

        if (Camera.main.TryGetComponent(out CameraRotate camera))
        {
            camera.enabled = false;
        }

        _timer.enabled = false;
        mover.enabled = false;
        cameraRotate.enabled = false;
        _unit.enabled = false;
    }
}
