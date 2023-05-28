using System.Collections.Generic;

public class Maze : IService
{
    private List<CellView> _cellViews = new List<CellView>();

    public void AddCell(CellView cellView)
    {
        _cellViews.Add(cellView);
    }

    public CellView GetRandomCellView()
    {
        if (_cellViews == null || _cellViews.Count == 0)
        {
            return null;
        }
        else
        {
            int random = UnityEngine.Random.Range(0, _cellViews.Count);

            return _cellViews[random];
        }
    }
}