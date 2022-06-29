using System.Reflection;
using Training_Center_Task_5;

var loggers = new Loggers();

loggers.LoadJson();
loggers.AddDLLToLoggersList();



var obj = new object();
