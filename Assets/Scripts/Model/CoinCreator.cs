using UnityEngine;

public class CoinCreator : MonoBehaviour
{
    [SerializeField] private Maze _maze;
    [SerializeField] private int _cointCount;
    [SerializeField] private GameObject _coinTemplate;

    private void OnEnable()
    {
        _maze.Created += OnMazeCreated;
    }

    private void OnMazeCreated()
    {
        CellView cellView;

        

        for (int i = 0; i < _cointCount; i++)
        {
            do
            {
                cellView = _maze.GetRandomCellView();
            } while (cellView.InsideCell != InsideCell.None);

            cellView.InsideCell = InsideCell.Coin;
            var coin = Instantiate(_coinTemplate);
            coin.transform.position = cellView.transform.position;
        }
    }
}
