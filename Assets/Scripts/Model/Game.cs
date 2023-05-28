using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private int _mazeSize;
    [SerializeField] private UnitMover _unitMover;
    [SerializeField] private MazeCreator _mazeCreator;
    [SerializeField] private Unit _unit;
    [SerializeField] private GameView _gameView;
    [SerializeField] private Timer _timer;

    private void Awake()
    {
        var maze = _mazeCreator.Create(_mazeSize);

        ServiceLocator.Instance.Register(_unitMover);
        ServiceLocator.Instance.Register(_unit);
        ServiceLocator.Instance.Register(maze);
        ServiceLocator.Instance.Register(_timer);

        ServiceLocator.Instance.Bind(_gameView, new GameViewModel());
    }
}
