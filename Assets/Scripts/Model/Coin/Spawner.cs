using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    private Maze _maze;
    private GameObject _template;
    private InsideCell _insideCell;
    private List<GameObject> _objects;

    public Spawner(Maze maze, GameObject template, InsideCell insideCell)
    {
        _maze = maze;
        _template = template;
        _insideCell = insideCell;
        _objects = new List<GameObject>();
    }

    public void Create(int count, int tries = 100)
    {
        for (int i = 0; i < count; i++)
        {
            CellView freeCell = GetEmptyCell(tries);

            if (freeCell != null)
            {
                _objects.Add(InstatntiateAt(freeCell, _template));
                freeCell.InsideCell = _insideCell;
            }
        }
    }

    public void Destroy()
    {
        foreach (GameObject obj in _objects)
        {
            Object.Destroy(obj);
        }
    }

    public CellView GetEmptyCell(int tries)
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

    private GameObject InstatntiateAt(CellView cellView, GameObject template)
    {
        var createdObject = Object.Instantiate(template);
        createdObject.transform.position = cellView.transform.position;
        return createdObject;
    }
}
