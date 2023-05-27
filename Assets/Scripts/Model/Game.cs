using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Unit _unit;

    private void Awake()
    {
        ServiceLocator.Instance.Register(_unit);
    }
}
