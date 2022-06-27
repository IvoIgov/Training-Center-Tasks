using Newtonsoft.Json;
using Training_Center_Task_5.JSONInfo;

namespace Training_Center_Task_5
{
    public class Loggers
    {
        public List<IListener> AllLoggers = new List<IListener>();

        public Loggers()
        {
            //1. reads appsettings
            //2. gets DLL names from 1.
            //3. from DLL name + reflection create objects of listeners
            //4. Adds objects from 3. to AllLoggers

            List<JSONItems> items = new List<JSONItems>();
            items = LoadJson(items);

        }

        public List<JSONItems> LoadJson(List<JSONItems> items)
        {
            using (StreamReader r = new StreamReader(@"C:\Users\IvoIgov\source\repos\Training_Center_Task_5\Training_Center_Task_5\appsettings.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject <List<JSONItems>>(json);
            }
            return items;
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
