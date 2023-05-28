public class MainMenuView : BaseView<MainMenuViewModel>
{
    public void OnPlay()
    {
        ViewModel.PlayCommand.Execute();
    }

    public void OnExit()
    {
        ViewModel.ExitCommand.Execute();
    }

    public void OnLeaderboard()
    {
        ViewModel.LeaderBoardCommand.Execute();
    }
}
