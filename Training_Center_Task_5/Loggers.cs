using Newtonsoft.Json;
using Training_Center_Task_5.JSONInfo;

namespace Training_Center_Task_5
{
    public class Loggers
    {
        public const string jsonPath = @"C:\Users\IvoIgov\source\repos\Training_Center_Task_5\Training_Center_Task_5\appsettings.json";
        private List<JSONItems> _items;
        public List<IListener> AllLoggers = new List<IListener>();

        public Loggers()
        {
            _items = new List<JSONItems>();
            //3. from DLL name + reflection create objects of listeners
            //4. Adds objects from 3. to AllLoggers

            
        }

        //1. reads appsettings
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                _items = JsonConvert.DeserializeObject <List<JSONItems>>(json);
            }
        }

        public void AddDLLToLoggersList()
        {
            //2. gets DLL names from 1.
            foreach (var item in _items)
            {
                if (item.ListenerName == "TextListener" || item.ListenerName == "WordListener" || item.ListenerName == "EventLogListener")
                {
                    string name = item.ListenerName + "s";
                    //IListener type = typeof();
                }
            }
        }

        public void Track(object obj)
        {
            //receive some info from obj
            foreach (var listener in AllLoggers)
            {
                listener.LogMessage("information from obj");
            }
        }
    }
}
