using UnityEngine;

public abstract class MazeCreator : MonoBehaviour
{
    [SerializeField] protected CellView CellViewTemplate;

    protected abstract Cell[,] GenerateMatrix();
    public abstract Maze Create(int size);
}
