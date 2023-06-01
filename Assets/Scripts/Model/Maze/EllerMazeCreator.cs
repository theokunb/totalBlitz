using System;
using System.Collections.Generic;
using UnityEngine;

public class EllerMazeCreator : MazeCreator
{
    private int _size;
    private List<CellView> _filledCells = new List<CellView>();
    private Maze _maze = new Maze();

    public override Maze Create(int size)
    {
        _size = size;

        var cells = GenerateMatrix();
        Vector2 position = new Vector2(-0.5f, 0.5f);

        if(_filledCells.Count != 0)
        {
            int counter = 0;

            foreach(var cell in _filledCells)
            {
                cell.Setup(cells[counter / size, counter % size]);
                counter++;
            }
        }
        else
        {
            for (int i = 1; i <= _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _maze.AddCell(CreateCell(cells[i - 1, j], i - 1, j, position + new Vector2((float)j / _size, (float)-i / _size)));
                }
            }
        }

        return _maze;
    }

    private CellView CreateCell(Cell cell,int i, int j, Vector2 position)
    {
        var cellView = Instantiate(CellViewTemplate, transform);
        cellView.transform.localScale = new Vector3(cellView.transform.localScale.x / _size, cellView.transform.localScale.y, cellView.transform.localScale.z / _size);
        cellView.transform.localPosition = new Vector3(position.x + cellView.transform.localScale.x / 2, cellView.transform.localPosition.y, position.y + cellView.transform.localScale.z / 2);
        cellView.Setup(cell);
        _filledCells.Add(cellView);

        return cellView;
    }

    protected override Cell[,] GenerateMatrix()
    {
        var cells = new Cell[_size, _size];

        CreateFirstLine(cells, 0);
        InitPlurality(cells, 0);
        CreateRightBounds(cells, 0);
        CreateBottomBounds(cells, 0);

        for (int i = 1; i < _size; i++)
        {
            CreateNewLine(cells, i);
            InitPlurality(cells, i);
            CreateRightBounds(cells, i);
            CreateBottomBounds(cells, i);

            if (i == _size - 1)
            {
                PerformLastLine(cells, i);
            }
        }

        return cells;
    }

    private void TryRandom(Action onSuccess = null, Action onFault = null)
    {
        int random = UnityEngine.Random.Range(0, 2);

        if (random != 0)
        {
            onFault?.Invoke();
        }
        else
        {
            onSuccess?.Invoke();
        }
    }

    private void CreateFirstLine(Cell[,] cells, int lineId)
    {
        for (int i = 0; i < _size; i++)
        {
            cells[lineId, i] = new Cell();
            cells[lineId, i].UpperBound = true;
        }

        CreateExtremeBounds(cells, lineId);
    }

    private void CreateExtremeBounds(Cell[,] cells, int lineId)
    {
        cells[lineId, 0].LeftBound = true;
        cells[lineId, _size - 1].RightBound = true;
    }

    private void InitPlurality(Cell[,] cells, int lineId)
    {
        for (int i = 0; i < _size; i++)
        {
            cells[lineId, i].InitPlurality();
        }
    }

    private void CreateRightBounds(Cell[,] cells, int lineId)
    {
        for (int i = 0; i < _size - 1; i++)
        {
            TryRandom(() =>
            {
                if (cells[lineId, i].Plurality.Id == cells[lineId, i + 1].Plurality.Id)
                {
                    cells[lineId, i].RightBound = true;
                }
            }, () =>
            {
                cells[lineId, i].MergeWith(cells[lineId, i + 1]);
            });
        }
    }

    private void CreateBottomBounds(Cell[,] cells, int lineId)
    {
        for (int i = 0; i < _size; i++)
        {
            TryRandom(() =>
            {
                if (cells[lineId, i].IsUniqueInPlurality() || cells[lineId, i].IsUniqueWithoutBottomBound())
                {

                }
                else
                {
                    cells[lineId, i].BottomBound = true;
                }
            });
        }
    }

    private void CreateNewLine(Cell[,] cells, int lineId)
    {
        if (lineId == 0 || lineId >= _size)
        {
            return;
        }

        for (int i = 0; i < _size; i++)
        {
            cells[lineId, i] = cells[lineId - 1, i].Clone() as Cell;
            cells[lineId, i].RightBound = false;
            cells[lineId, i].UpperBound = false;

            if (cells[lineId, i].BottomBound == true)
            {
                cells[lineId, i].LeavePlurality();
                cells[lineId, i].BottomBound = false;
            }
        }

        CreateExtremeBounds(cells, lineId);
    }

    private void PerformLastLine(Cell[,] cells, int lineId)
    {
        for (int i = 0; i < _size; i++)
        {
            cells[lineId, i].BottomBound = true;
        }

        for (int i = 0; i < _size - 1; i++)
        {
            if (cells[lineId, i].Plurality.Id != cells[lineId, i + 1].Plurality.Id)
            {
                cells[lineId, i].RightBound = false;
                cells[lineId, i].MergeWith(cells[lineId, i + 1]);
            }
        }
    }
}
