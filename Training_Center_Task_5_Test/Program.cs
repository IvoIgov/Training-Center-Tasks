using System.Reflection;
using Training_Center_Task_5;

var loggers = new Loggers();

loggers.LoadJson();
loggers.AddDLLToLoggersList();

SampleClass sampleClass = new SampleClass("name", "description", "notes");

loggers.Track(sampleClass);



var obj = new object();
