using System.Linq;
using UnityEngine;

public class HearingDetector : Detector
{
    public HearingDetector(float radius, uint priority) : base(radius, priority)
    {
    }

    public override bool TryDetect(Vector3 position, out Unit unit)
    {
        var colliders = Physics.OverlapSphere(position, Radius);

        unit = colliders
            .Where(element => element.TryGetComponent(out Unit _) == true)
            .Select(element => element.GetComponent<Unit>())
            .FirstOrDefault();

        return unit != null;
    }
}