using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private UnitMover _unit;

    private void Awake()
    {
        ServiceLocator.Instance.Register(_unit);
    }
}
