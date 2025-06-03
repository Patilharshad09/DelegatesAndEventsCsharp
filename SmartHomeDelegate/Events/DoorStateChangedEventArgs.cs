public class DoorStateChangedEventArgs
    : SmartHomeEventArgs
{
    public string DoorName { get;}
    public bool IsOpen { get; }
    public DoorStateChangedEventArgs(string sensorName, string doorName, bool isOpen) : base(sensorName) => (DoorName, IsOpen) = (doorName, isOpen);

    public override string ToString() => $"Door {DoorName} - Is Open {IsOpen}";
    
}