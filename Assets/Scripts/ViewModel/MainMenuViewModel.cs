using UniRx;

public class MainMenuViewModel : BaseViewModel
{
    private CompositeDisposable _disposables;

    public ReactiveCommand LeaderBoardCommand { get; private set; }

    public MainMenuViewModel()
    {
        _disposables = new CompositeDisposable();
        LeaderBoardCommand = new ReactiveCommand();

        LeaderBoardCommand.Subscribe(_ => OnLeaderboard())
            .AddTo(_disposables);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _disposables.Dispose();
    }

    private void OnLeaderboard()
    {
        var leaderboardView = ServiceLocator.Instance.Get<LeaderboardView>();
        leaderboardView.gameObject.SetActive(true);
    }
}
