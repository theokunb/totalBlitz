using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _baseOffset;
    [SerializeField] private LayerMask _layerMask;


    private void Start()
    {
        transform.position = _baseOffset.position;
    }

    private void Update()
    {
        if (Physics.Linecast(_baseOffset.position, _target.position, out RaycastHit hit, _layerMask))
        {
            transform.position = hit.point;
        }
    }
}
