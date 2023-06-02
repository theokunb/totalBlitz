using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject _unit;
    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private int _cointsCount;
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private int _enemyCount;
    [SerializeField] private int tries;

    private Spawner _coinSpawner;
    private Spawner _enemySpawner;
    private Maze _maze;

    public void Fill(Maze maze)
    {
        _coinSpawner?.Destroy();
        _enemySpawner?.Destroy();
        _maze = maze;

        _coinSpawner = _coinSpawner ?? new Spawner(_maze, _coinTemplate, InsideCell.Coin);
        _enemySpawner = _enemySpawner ?? new Spawner(_maze, _enemyTemplate, InsideCell.Enemy);

        CellView cellView = _coinSpawner.GetEmptyCell(tries);
        _unit.transform.position = cellView.transform.position;

        _coinSpawner.Create(_cointsCount);
        _enemySpawner.Create(_enemyCount);
    }
}
