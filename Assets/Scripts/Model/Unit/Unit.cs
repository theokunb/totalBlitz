using UnityEngine;

public class Unit : MonoBehaviour, ICollector
{
    private int _collectedValue = 0;

    public void Collect(ICollectable collectable)
    {
        _collectedValue += collectable.Value;
        collectable.OnCollected();
    }
}