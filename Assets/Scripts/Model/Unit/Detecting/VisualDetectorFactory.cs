public class VisualDetectorFactory : DetectorFactory
{
    public override Detector CreateDetector(float Radius, uint priority)
    {
        return new VisualDetector(Radius, priority);
    }
}