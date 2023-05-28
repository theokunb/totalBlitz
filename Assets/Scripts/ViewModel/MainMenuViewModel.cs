using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuViewModel : BaseViewModel
{
    private CompositeDisposable _disposables;

    public ReactiveCommand PlayCommand { get; private set; }
    public ReactiveCommand ExitCommand { get; private set; }
    public ReactiveCommand LeaderBoardCommand { get; private set; }

    public MainMenuViewModel()
    {
        _disposables = new CompositeDisposable();
        PlayCommand = new ReactiveCommand();
        ExitCommand = new ReactiveCommand();
        LeaderBoardCommand = new ReactiveCommand();

        PlayCommand.Subscribe(_ => OnPlay())
            .AddTo(_disposables);
        ExitCommand.Subscribe(_ => OnExit())
            .AddTo(_disposables);
        LeaderBoardCommand.Subscribe(_ => OnLeaderboard())
            .AddTo(_disposables);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _disposables.Dispose();
    }

    private void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    private void OnExit()
    {
        Application.Quit();
    }

    private void OnLeaderboard()
    {
        var leaderboardView = ServiceLocator.Instance.Get<LeaderboardView>();
        leaderboardView.gameObject.SetActive(true);
    }
}
