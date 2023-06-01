using UniRx;

public class GameMenuViewModel : BaseViewModel
{
    private CompositeDisposable _disposables;

    public ReactiveCommand ReplayCommand { get; private set; }
    public ReactiveCommand ExitCommand { get; private set; }

    public GameMenuViewModel()
    {
        _disposables = new CompositeDisposable();
        ReplayCommand = new ReactiveCommand();
        ExitCommand = new ReactiveCommand();
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _disposables.Dispose();
    }
}
