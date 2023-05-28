using System.Collections;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _scaleFactor;
    [SerializeField] private int _reward;

    private bool _canRotate;
    private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

    public int Value => _reward;

    private void Start()
    {
        _canRotate = true;
        StartCoroutine(RotateTask());
        _tween = transform.DOScale(transform.localScale * _scaleFactor, 1).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }

    private IEnumerator RotateTask()
    {
        while (_canRotate)
        {
            transform.localEulerAngles += Vector3.up * _rotationSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ICollector collector))
        {
            collector.Collect(this);
        }
    }

    public void OnCollected()
    {
        Destroy(gameObject);
    }
}
