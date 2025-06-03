using System;

public class SmartHomeEventArgs : EventArgs
{
    public DateTime Timestamp { get; }
    public string SensorName { get; }

    public SmartHomeEventArgs(string sensorName)
    {
        Timestamp = DateTime.Now;
        SensorName = sensorName;
    } 
 }