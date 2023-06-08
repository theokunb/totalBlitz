using UniRx;
using UnityEngine;

public class Unit : MonoBehaviour, ICollector, IService
{
    public IntReactiveProperty CollectedValue;
    public bool Catched { get; set; } = false;

    public void Collect(ICollectable collectable)
    {
        CollectedValue.Value += collectable.Value;
        collectable.OnCollected();
    }

    public void ResetCoins()
    {
        CollectedValue.Value = 0;
    }
}