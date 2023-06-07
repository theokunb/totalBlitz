using System.Linq;
using UnityEngine;

public abstract class Detector
{
    public uint Priority { get; private set; }
    protected float Radius { get; private set; }

    public Detector(float radius, uint priority)
    {
        Radius = radius;
        Priority = priority;
    }

    public abstract bool TryDetect(Vector3 position, out Unit unit);

    public static bool CompositeDetect(Vector3 position,out Unit unit, params Detector[] detectors)
    {
        var sortedDetectors = detectors.OrderByDescending(detector => detector.Priority).ToArray();
        unit = null;

        foreach (var detector in sortedDetectors)
        {
            if(detector.TryDetect(position, out unit))
            {
                return true;
            }
        }

        return false;
    }
}