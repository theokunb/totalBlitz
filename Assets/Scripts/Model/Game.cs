using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private int _mazeSize;
    [SerializeField] private UnitMover _unit;
    [SerializeField] private MazeCreator _mazeCreator;

    private void Awake()
    {
        var maze = _mazeCreator.Create(_mazeSize);

        ServiceLocator.Instance.Register(_unit);
        ServiceLocator.Instance.Register(maze);
    }
}
