using System.Diagnostics;
using Training_Center_Task_5;

namespace EventLogListener
{
    public class EventLogListeners :IListener
    {
        public void LogMessage(string message)
        {
            using (EventLog eventLog = new EventLog())
            {
                if (!EventLog.SourceExists("TestApplication"))
                {
                    EventLog.CreateEventSource("TestApplication", "Application");
                }

                eventLog.Source = "TestApplication";
                eventLog.WriteEntry(message, EventLogEntryType.Information);
                eventLog.Clear();
            }
        }
    }
}