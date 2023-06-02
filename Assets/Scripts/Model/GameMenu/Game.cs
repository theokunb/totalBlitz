using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private MainMenuView _mainView;
    [SerializeField] private GameView _gameView;
    [SerializeField] private LeaderboardView _leaderboardView;
    [SerializeField] private int _mazeSize;
    [SerializeField] private MazeCreator _mazeCreator;
    [SerializeField] private Unit _unit;
    [SerializeField] private CameraRotate _unitRotate;
    [SerializeField] private Timer _timer;
    [SerializeField] private SpawnerManager _coinCreator;

    private Storage _storage;
    private Maze _maze;

    private void Awake()
    {
        NewGame();
        _storage = new FileStorage();

        ServiceLocator.Instance.Register(_unit);
        ServiceLocator.Instance.Register(_maze);
        ServiceLocator.Instance.Register(_timer);
        ServiceLocator.Instance.Register(_unitRotate);
        ServiceLocator.Instance.Register(_storage);

        ServiceLocator.Instance.Bind(_gameView, new GameViewModel());
        ServiceLocator.Instance.Bind(_mainView, new MainMenuViewModel());
        ServiceLocator.Instance.Bind(_leaderboardView, new  LeaderboardViewModel());
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<Unit>();
        ServiceLocator.Instance.Unregister<Maze>();
        ServiceLocator.Instance.Unregister<Timer>();
        ServiceLocator.Instance.Unregister<CameraRotate>();
        ServiceLocator.Instance.Unregister<GameView>();
        ServiceLocator.Instance.Unregister<GameMenu>();
        ServiceLocator.Instance.Unregister<Storage>();
        ServiceLocator.Instance.Unregister<MainMenuView>();
        ServiceLocator.Instance.Unregister<LeaderboardView>();
    }

    public void NewGame()
    {
        _maze = _mazeCreator.Create(_mazeSize);
        _coinCreator.Fill(_maze);
        _timer.ResetSeconds();
    }

    public void StartTime()
    {
        Time.timeScale = 1f;
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }
}
