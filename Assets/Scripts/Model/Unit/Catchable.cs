using UnityEngine;

public class Catchable : MonoBehaviour
{
    private Unit _unit;


    private void Start()
    {
        _unit = GetComponentInParent<Unit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyInput _))
        {
            if (_unit != null)
            {
                _unit.Catched = true;
            }
        }
    }
}
