using System;
namespace SmartHomeDelegate.Devices
{
	public class HomeLogger
	{
		public void LogAllEvents<T>(object sender, T eventargs) where T : SmartHomeEventArgs
		{
			Console.WriteLine($"Timestamp : {eventargs.Timestamp} and the Sensorname is {eventargs.SensorName}");
		}
	}
}

