public class HearingDetectorFactory : DetectorFactory
{
    public override Detector CreateDetector(float Radius,uint priority)
    {
        return new HearingDetector(Radius, priority);
    }
}