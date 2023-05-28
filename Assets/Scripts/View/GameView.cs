using TMPro;
using UnityEngine;
using UniRx;
using System;

public class GameView : BaseView<GameViewModel>
{
    private CompositeDisposable _disposables;

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _timeText;

    protected override void OnInitialized()
    {
        _disposables = new CompositeDisposable();

        ViewModel.Score.Subscribe(value => OnScoreChanged(value))
            .AddTo(_disposables);
        ViewModel.Time.Subscribe(value => OnTimeChnaged(value))
            .AddTo(_disposables);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _disposables.Dispose();
    }

    private void OnScoreChanged(int value)
    {
        _scoreText.text = $"score: {value}";
    }

    private void OnTimeChnaged(float value)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(value);

        _timeText.text = $"{timeSpan.Minutes} : {timeSpan.Seconds}";
    }
}
