using Newtonsoft.Json;
using System.Reflection;
using Training_Center_Task_5.JSONInfo;

namespace Training_Center_Task_5
{
    public class Loggers
    {
        public const string _jsonPath = LogFilesPaths.JsonPath;
        public const string _interfaceName = "IListener";


        private List<JSONItems> _items;
        public List<IListener> AllLoggers = new List<IListener>();

        public Loggers()
        {
            _items = new List<JSONItems>();
        }

        //1. reads appsettings
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(_jsonPath))
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

                    if (res.Length > 0 && res[0].Name == _interfaceName)
                    {
                        Type listenerType = assembly.GetType(type.FullName);
                        AllLoggers.Add((IListener)Activator.CreateInstance(listenerType));
                    }
                }
            }
        }

        public void Track(SampleClass sampleClass)
        {
            Type type = typeof(SampleClass);
            Attribute[] allAttrs = Attribute.GetCustomAttributes(type);

            if (Attribute.GetCustomAttribute(typeof(SampleClass), typeof(TrackingEntity)) != null)
            {

            }
            else
            {
                return;
            }

            List<KeyValuePair<string, string>> attributeInfo = new List<KeyValuePair<string, string>>();


            PropertyInfo[] props = typeof(SampleClass).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    TrackingProperty sampleClassAttr = attr as TrackingProperty;
                    if (sampleClassAttr != null)
                    {
                        string propName = prop.Name;
                        string auth = sampleClass.Name;

                        KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>(propName, auth);

                        attributeInfo.Add(keyValuePair);
                    }
                }
            }

            foreach(var item in attributeInfo)
            {
                foreach (var listener in AllLoggers)
                {
                    listener.LogMessage($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
