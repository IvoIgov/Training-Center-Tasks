using Newtonsoft.Json;
using System.Reflection;
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
                _items = JsonConvert.DeserializeObject<List<JSONItems>>(json);
            }
        }

        public void AddDLLToLoggersList()
        {
            //2. gets DLL names from 1.
            foreach (var item in _items)
            {
                string listenerName = item.ListenerName.Substring(0, item.ListenerName.Length - 4);

                var assembly = Assembly.LoadFrom($"C:\\Users\\IvoIgov\\source\\repos\\Training_Center_Task_5\\{listenerName}\\bin\\Debug\\net6.0\\" + item.ListenerName);
            
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    var res = type.GetInterfaces();

                    if (res.Length > 0 && res[0].Name == "IListener")
                    {
                        Type listenerType = assembly.GetType(type.FullName);
                        Console.WriteLine(listenerType);
                        AllLoggers.Add((IListener)Activator.CreateInstance(listenerType));
                    }
                }
            }
        }

        public void Track(object obj)
        {
            var attrs = typeof(SampleClass).GetProperties();

            foreach (var attr in attrs)
            {
                if (attr.ToString() == "TrackingEntity")
                {
                    foreach (var listener in AllLoggers)
                    {
                        listener.LogMessage("information from obj");
                    }
                }
            }
        }
    }
}
