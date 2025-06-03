public class TemperatureSensor : SmartSensor
{
    public double _currentTemperature;
    public event SmartHomeEventHandler<TemperatureChangedEventArgs>? _TemperatureChanged;
    
    public TemperatureSensor(string Name, double currnetTemperature) : base(Name)
=> (_currentTemperature) = (currnetTemperature);

    public void SimulateTemperatureChange(double Temperature)
    {
        _TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(Name, Temperature, _currentTemperature));
    }
}