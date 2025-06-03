public class MotionSensor : SmartSensor
{
    public string zone;
    public event SmartHomeEventHandler<MotionDetectedEventArgs>? _MotionDetected;
    public MotionSensor(string Name, string Zone) : base(Name) => (zone) = (Zone);
    public void SimulateMotion(bool detected)
    {
        _MotionDetected?.Invoke(this, new MotionDetectedEventArgs(Name, detected, zone));
    }
   
}