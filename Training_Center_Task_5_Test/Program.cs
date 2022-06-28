using System.Reflection;
using Training_Center_Task_5;

var loggers = new Loggers();

loggers.LoadJson();
loggers.AddDLLToLoggersList();

var attrs = typeof(Program).GetCustomAttributes();

foreach (var attr in attrs)
{
    if (attr.ToString() == "TrackingEntity")
    {

    }
}

var obj = new object();

loggers.Track(attrs);
