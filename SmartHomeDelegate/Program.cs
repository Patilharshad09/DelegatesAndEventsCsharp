using SmartHomeDelegate.Devices;

TemperatureSensor livingRoomSensor = new TemperatureSensor("LivingRoom_Temp_Sensor", 12.4);
MotionSensor kichenSensor = new MotionSensor("Kitchen_Motion_Sensor", "Chimni");
MotionSensor mainEntry = new MotionSensor("MainEntry_Motion_Sensor", "Entry");
DoorSensor doorSensor = new DoorSensor("MainDoor_Sensor", "Main Door");

var hallwayLight = new SmartLight("Hallway_Light");
var kitchenLight = new SmartLight("Kitchen_Light");
var homeThermostat = new SmartThermostat("Main_Zone");
var centralSecurity = new SecuritySystem("Central_Security");
var systemLogger = new HomeLogger();

livingRoomSensor._TemperatureChanged += homeThermostat.OnTemperatureChanged;
livingRoomSensor._TemperatureChanged += homeThermostat.OnTemperatureChanged;
livingRoomSensor._TemperatureChanged += systemLogger.LogAllEvents;

// --- Motion Sensor Subscriptions ---
kichenSensor._MotionDetected += hallwayLight.OnMotionDetected;
kichenSensor._MotionDetected += systemLogger.LogAllEvents;
kichenSensor._MotionDetected += centralSecurity.OnMotionDetected;

mainEntry._MotionDetected += hallwayLight.OnMotionDetected;
mainEntry._MotionDetected += systemLogger.LogAllEvents;
mainEntry._MotionDetected += centralSecurity.OnMotionDetected;

livingRoomSensor.SimulateTemperatureChange(21.5);
kichenSensor.SimulateMotion(true);
mainEntry.SimulateMotion(false);
doorSensor.SimulateDoorState(false);