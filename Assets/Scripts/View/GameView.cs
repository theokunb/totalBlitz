using TMPro;
using UnityEngine;
using UniRx;

public class GameView : BaseView<GameViewModel>
{
    private CompositeDisposable _disposables;

    [SerializeField] private TMP_Text _scoreText;

    protected override void OnInitialized()
    {
        _disposables = new CompositeDisposable();

        ViewModel.Score.Subscribe(value => OnScoreChanged(value))
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
}
