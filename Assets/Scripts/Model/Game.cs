using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private int _mazeSize;
    [SerializeField] private MazeCreator _mazeCreator;
    [SerializeField] private UnitMover _unitMover;
    [SerializeField] private Unit _unit;
    [SerializeField] private CameraRotate _unitRotate;
    [SerializeField] private GameView _gameView;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameMenu _gameMenu;

    private void Awake()
    {
        var maze = _mazeCreator.Create(_mazeSize);

        ServiceLocator.Instance.Register(_unitMover);
        ServiceLocator.Instance.Register(_unit);
        ServiceLocator.Instance.Register(maze);
        ServiceLocator.Instance.Register(_timer);
        ServiceLocator.Instance.Register(_unitRotate);

        ServiceLocator.Instance.Bind(_gameView, new GameViewModel());
        ServiceLocator.Instance.Bind(_gameMenu, new GameMenuViewModel());
    }

    private void OnDestroy()
    {
        ServiceLocator.Instance.Unregister<UnitMover>();
        ServiceLocator.Instance.Unregister<Unit>();
        ServiceLocator.Instance.Unregister<Maze>();
        ServiceLocator.Instance.Unregister<Timer>();
        ServiceLocator.Instance.Unregister<CameraRotate>();
        ServiceLocator.Instance.Unregister<GameView>();
        ServiceLocator.Instance.Unregister<GameMenu>();
    }
}
