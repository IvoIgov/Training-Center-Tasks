using System.Diagnostics;

namespace EventLogListener
{
    public class EventLogListeners
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
                //eventLog.Clear();
            }
        }
    }
}