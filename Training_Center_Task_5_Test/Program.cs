using Training_Center_Task_5;
using Training_Center_Task_5.JSONInfo;

var loggers = new Loggers();

loggers.LoadJson();
loggers.AddDLLToLoggersList();
var obj = new object();
loggers.Track(obj);
