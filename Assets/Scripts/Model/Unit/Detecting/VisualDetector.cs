using System.Linq;
using UnityEngine;

public class VisualDetector : Detector
{
    public VisualDetector(float radius,uint priority) : base(radius, priority)
    {
    }

    public override bool TryDetect(Vector3 position, out Unit unit)
    {
        var colliders = Physics.OverlapSphere(position, Radius);
        unit = null;

        Unit[] units = colliders
            .Where(element => element.TryGetComponent(out Unit _) == true)
            .Select(element => element.GetComponent<Unit>())
            .ToArray();

        foreach (var collidedUnit in units)
        {
            if (Physics.Linecast(position + Vector3.up/2, collidedUnit.transform.position + Vector3.up/2, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Catchable _) == true)
                {
                    unit = collidedUnit;
                    return true;
                }
            }
        }

        return false;
    }
}