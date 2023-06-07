public abstract class DetectorFactory : IService
{
    public abstract Detector CreateDetector(float Radius, uint priority);
}