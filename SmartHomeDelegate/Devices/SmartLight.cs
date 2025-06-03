using System;
namespace SmartHomeDelegate.Devices
{
	public class SmartLight
	{
		public string Name { get; }
		public bool _isOn;
		public SmartLight(string name) => (Name,_isOn) = (name,false);

        public void TurnOn()
        {
            if (!_isOn)
            {
                _isOn = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  [{Name} Light]: Turning ON!");
                Console.ResetColor();
            }
        }

        public void TurnOff()
        {
            if (_isOn)
            {
                _isOn = false;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"  [{Name} Light]: Turning OFF.");
                Console.ResetColor();
            }
        }


        public void OnMotionDetected(object sender, MotionDetectedEventArgs e)
		{
			Console.WriteLine($"Name {Name} Motion detected by {e.SensorName} in {e.Zone} at {e.Timestamp} as  {e.IsMotionDetected}");
            if (e.IsMotionDetected)
            {
                Console.WriteLine($"  [{Name} Light]: Motion detected by {e.SensorName} in {e.Zone}. Turning on.");
                TurnOn();
            }
            else
            {
                Console.WriteLine($"  [{Name} Light]: No motion in {e.Zone}. Turning off after delay.");
                // In a real system, you'd have a timer here to turn off after X seconds
                // For this simulation, we'll just log the intent.
            }
        }
		public void OnDoorStateChanged(object sender, DoorStateChangedEventArgs e)
		{
			Console.WriteLine($"Door state changed {e.DoorName} at {e.Timestamp} and is open : {e.IsOpen} by the sensor name {e.SensorName}");
            if (e.IsOpen)
            {
                Console.WriteLine($"  [{Name} Light]: {e.DoorName} opened by {e.SensorName}. Turning on.");
                TurnOn();
            }
            else
            {
                Console.WriteLine($"  [{Name} Light]: {e.DoorName} closed by {e.SensorName}. Turning off.");
                TurnOff();
            }
        }
	}
}

