using System;
using UniRx;
using UnityEngine;

public class Timer : MonoBehaviour, IService
{
    [SerializeField] private float _baseTime;

    public FloatReactiveProperty Seconds { get; private set; } = new FloatReactiveProperty();

    public event Action TimeUp;

    public void Update()
    {
        Seconds.Value -= Time.deltaTime;

        if (Seconds.Value <= 0)
        {
            TimeUp?.Invoke();
        }
    }

    public void ResetSeconds()
    {
        Seconds.Value = _baseTime;
    }
}
