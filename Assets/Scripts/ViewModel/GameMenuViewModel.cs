using UniRx;
using UnityEngine.SceneManagement;

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

        ReplayCommand.Subscribe(_ => OnReplay())
            .AddTo(_disposables);
        ExitCommand.Subscribe(_ => OnExit())
            .AddTo(_disposables);
    }

    public override void Unsubscribe()
    {
        base.Unsubscribe();
        _disposables.Dispose();
    }

    private void OnReplay()
    {
        SceneManager.LoadScene(1);
    }

    private void OnExit()
    {
        SceneManager.LoadScene(0);
    }
}
