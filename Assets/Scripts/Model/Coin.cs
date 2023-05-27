using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _scaleFactor;

    private bool _canRotate;

    private void Start()
    {
        _canRotate = true;
        StartCoroutine(RotateTask());
        transform.DOScale(transform.localScale * _scaleFactor, 1).SetLoops(-1, LoopType.Yoyo);
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

    }
}
