using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UnitMover _unit;
    [SerializeField] private Maze _maze;

    private void Awake()
    {
        ServiceLocator.Instance.Register(_unit);
    }

    private void OnEnable()
    {
        _maze.Created += OnCreated;
    }

    private void OnDisable()
    {
        _maze.Created -= OnCreated;
    }

    private void OnCreated()
    {
        var cell = _maze.GetRandomCellView();
        cell.InsideCell = InsideCell.Start;
        _unit.transform.position = cell.transform.position;
    }
}
