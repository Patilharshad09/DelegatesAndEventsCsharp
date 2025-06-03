public class DoorSensor : SmartSensor
{
    public string DoorName { get; }

    public event SmartHomeEventHandler<DoorStateChangedEventArgs>? _DoorStateChanged;

    public DoorSensor(string Name, string doorName) : base(Name) => (DoorName) = (doorName);

    public void SimulateDoorState(bool isOpen)
    {
        _DoorStateChanged?.Invoke(this, new DoorStateChangedEventArgs(Name, DoorName, isOpen));
    }

}