using System;
namespace SmartHomeDelegate.Devices
{
    public class SecuritySystem
    {
        public string Name { get; }
        private bool _isArmed;

        public SecuritySystem(string name)
        {
            Name = name;
            _isArmed = false;
            Console.WriteLine($"[{Name} Security System]: Initialized (Armed: {_isArmed}).");
        }

        public void Arm()
        {
            _isArmed = true;
            Console.WriteLine($"  [{Name} Security System]: System ARMED.");
        }

        public void Disarm()
        {
            _isArmed = false;
            Console.WriteLine($"  [{Name} Security System]: System DISARMED.");
        }

        private void TriggerAlarm(string reason)
        {
            if (_isArmed)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"  [{Name} Security System]: !!! ALARM ACTIVATED !!! Reason: {reason}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  [{Name} Security System]: Potential breach ({reason}) but system is DISARMED.");
            }
        }

        // Event Handlers
        public void OnMotionDetected(object sender, MotionDetectedEventArgs e)
        {
            if (e.IsMotionDetected)
            {
                Console.WriteLine($"  [{Name} Security System]: Motion detected by {e.SensorName} in {e.Zone}.");
                TriggerAlarm($"Unauthorized motion in {e.Zone}");
            }
        }

        public void OnDoorStateChanged(object sender, DoorStateChangedEventArgs e)
        {
            if (e.IsOpen)
            {
                Console.WriteLine($"  [{Name} Security System]: {e.DoorName} opened by {e.SensorName}.");
                TriggerAlarm($"Unauthorized door open: {e.DoorName}");
            }
        }
    }
}

