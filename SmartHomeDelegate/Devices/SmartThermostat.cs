using System;
namespace SmartHomeDelegate.Devices
{
    public class SmartThermostat
    {
        public string Location { get; }
        private double _targetTemperature = 22.0;

        public SmartThermostat(string location)
        {
            Location = location;
            Console.WriteLine($"[{Location} Thermostat]: Initialized. Target: {_targetTemperature}°C.");
        }

        public void AdjustTemperature(double currentTemp)
        {
            Console.WriteLine($"  [{Location} Thermostat]: Current temp: {currentTemp}°C. Target: {_targetTemperature}°C.");
            if (currentTemp < _targetTemperature - 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"    [{Location} Thermostat]: Temperature too low. Turning on heating.");
                Console.ResetColor();
            }
            else if (currentTemp > _targetTemperature + 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"    [{Location} Thermostat]: Temperature too high. Turning on cooling.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"    [{Location} Thermostat]: Temperature is comfortable.");
            }
        }

        // Event Handler
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"  [{Location} Thermostat]: Temperature change detected by {e.SensorName}.");
            AdjustTemperature(e.CurrentTemperature);
        }
    }
}

