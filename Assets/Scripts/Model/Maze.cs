using System;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField] private int _size;
    [SerializeField] private CellView _cellTemplate;

    private Cell[,] _array;
    private List<CellView> _cellViews;

    public event Action Created;

    private void Awake()
    {
        _array = new Cell[_size, _size];
        _cellViews = new List<CellView>();

        CreateFirstLine(0);
        InitPlurality(0);
        CreateRightBounds(0);
        CreateBottomBounds(0);

        for (int i = 1; i < _size; i++)
        {
            CreateNewLine(i);
            InitPlurality(i);
            CreateRightBounds(i);
            CreateBottomBounds(i);

            if (i == _size - 1)
            {
                PerformLastLine(i);
            }
        }
    }

    private void Start()
    {
        Vector2 position = new Vector2(-0.5f, 0.5f);

        for (int i = 1; i <= _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                CreateCell(i - 1, j, position + new Vector2((float)j / _size, (float)-i / _size));
            }
        }

        Created?.Invoke();
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

    private void CreateCell(int i, int j, Vector2 position)
    {
        var cellView = Instantiate(_cellTemplate, transform);
        cellView.transform.localScale = new Vector3(cellView.transform.localScale.x / _size, cellView.transform.localScale.y, cellView.transform.localScale.z / _size);
        cellView.transform.localPosition = new Vector3(position.x + cellView.transform.localScale.x / 2, cellView.transform.localPosition.y, position.y + cellView.transform.localScale.z / 2);
        cellView.Setup(_array[i, j]);

        _cellViews.Add(cellView);
    }

    private void TryRandom(Action onSuccess = null, Action onFault = null)
    {
        int random = UnityEngine.Random.Range(0, 2);

        if (random == 0)
        {
            onFault?.Invoke();
        }
        else
        {
            onSuccess?.Invoke();
        }
    }

    private void CreateFirstLine(int lineId)
    {
        for (int i = 0; i < _size; i++)
        {
            _array[lineId, i] = new Cell();
            _array[lineId, i].UpperBound = true;
        }

        CreateExtremeBounds(lineId);
    }

    private void CreateExtremeBounds(int lineId)
    {
        _array[lineId, 0].LeftBound = true;
        _array[lineId, _size - 1].RightBound = true;
    }

    private void InitPlurality(int lineId)
    {
        for (int i = 0; i < _size; i++)
        {
            _array[lineId, i].InitPlurality();
        }
    }

    private void CreateRightBounds(int lineId)
    {
        for (int i = 0; i < _size - 1; i++)
        {
            TryRandom(() =>
            {
                if (_array[lineId, i].Plurality.Id == _array[lineId, i + 1].Plurality.Id)
                {
                    _array[lineId, i].RightBound = true;
                }
            }, () =>
            {
                _array[lineId, i].MergeWith(_array[lineId, i + 1]);
            });
        }
    }

    private void CreateBottomBounds(int lineId)
    {
        for (int i = 0; i < _size; i++)
        {
            TryRandom(() =>
            {
                if (_array[lineId, i].IsUniqueInPlurality() || _array[lineId, i].IsUniqueWithoutBottomBound())
                {

                }
                else
                {
                    _array[lineId, i].BottomBound = true;
                }
            });
        }
    }

    private void CreateNewLine(int lineId)
    {
        if (lineId == 0 || lineId >= _size)
        {
            return;
        }

        for (int i = 0; i < _size; i++)
        {
            _array[lineId, i] = _array[lineId - 1, i].Clone() as Cell;
            _array[lineId, i].RightBound = false;
            _array[lineId, i].UpperBound = false;

            if (_array[lineId, i].BottomBound == true)
            {
                _array[lineId, i].LeavePlurality();
                _array[lineId, i].BottomBound = false;
            }
        }

        CreateExtremeBounds(lineId);
    }

    private void PerformLastLine(int lineId)
    {
        for (int i = 0; i < _size; i++)
        {
            _array[lineId, i].BottomBound = true;
        }

        for (int i = 0; i < _size - 1; i++)
        {
            if (_array[lineId, i].Plurality.Id != _array[lineId, i + 1].Plurality.Id)
            {
                _array[lineId, i].RightBound = false;
                _array[lineId, i].MergeWith(_array[lineId, i + 1]);
            }
        }
    }
}