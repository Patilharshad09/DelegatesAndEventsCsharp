public class MotionDetectedEventArgs : SmartHomeEventArgs
{
    public bool IsMotionDetected { get; }
    public string Zone { get; }
    public MotionDetectedEventArgs(string senserName, bool isMotionDetected, string zone) : base(senserName) => (IsMotionDetected, Zone) = (isMotionDetected, zone);
    public override string ToString() => $"Motion in zone : {Zone} - Is detected  {IsMotionDetected}";
}