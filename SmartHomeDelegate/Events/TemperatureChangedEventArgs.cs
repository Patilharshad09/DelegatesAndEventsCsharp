public class TemperatureChangedEventArgs : SmartHomeEventArgs
{
    public double CurrentTemperature { get; }
    public double PreviousTemperature { get; }

    public TemperatureChangedEventArgs(string sensorName, double currentTemperature, double previousTemperature) : base(sensorName)
    => (CurrentTemperature, PreviousTemperature) = (currentTemperature, previousTemperature);
}