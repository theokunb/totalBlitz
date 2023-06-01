using System;
using TMPro;
using UniRx;
using UnityEngine;

public class GameView : BaseView<GameViewModel>
{
    [SerializeField] private Game _game;

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
        ViewModel.EndGame += OnEndGame;
    }

    private void OnEndGame()
    {
        _game.NewGame();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _disposables.Dispose();
        ViewModel.EndGame -= OnEndGame;
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
