using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _cointCount;
    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private GameObject _unit;

    private Maze _maze;
    private int tries = 10;
    private List<GameObject> _coins = new List<GameObject>();

    public void Fill(Maze maze)
    {
        foreach (var coin in _coins)
        {
            Destroy(coin.gameObject);
        }

        _maze = maze;
        CellView cellView = GetEmptyCell(tries);
        _unit.transform.position = cellView.transform.position;

        for (int i = 0; i < _cointCount; i++)
        {
            cellView = GetEmptyCell(tries);
            cellView.InsideCell = InsideCell.Coin;
            _coins.Add(InstatntiateAt(cellView, _coinTemplate));
        }
    }

    private GameObject InstatntiateAt(CellView cellView, GameObject template)
    {
        var createdObject = Instantiate(template);
        createdObject.transform.position = cellView.transform.position;
        return createdObject;
    }

    private CellView GetEmptyCell(int tries)
    {
        int counter = 0;
        CellView cellView;

        do
        {
            counter++;
            cellView = _maze.GetRandomCellView();
        } while (cellView.InsideCell != InsideCell.None && counter < tries);

        return cellView;
    }
}
