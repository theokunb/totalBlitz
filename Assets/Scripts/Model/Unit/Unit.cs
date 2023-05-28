using UniRx;
using UnityEngine;

public class Unit : MonoBehaviour, ICollector, IService
{
    public IntReactiveProperty CollectedValue { get; private set; }

    public void Collect(ICollectable collectable)
    {
        CollectedValue.Value += collectable.Value;
        collectable.OnCollected();
    }
}