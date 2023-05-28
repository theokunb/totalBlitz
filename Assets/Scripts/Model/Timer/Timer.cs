using System;
using UniRx;
using UnityEngine;

public class Timer : MonoBehaviour, IService
{
    public FloatReactiveProperty Seconds = new FloatReactiveProperty();

    public event Action TimeUp;

    public void Update()
    {
        Seconds.Value -= Time.deltaTime;

        if (Seconds.Value <= 0)
        {
            TimeUp?.Invoke();
        }
    }
}
