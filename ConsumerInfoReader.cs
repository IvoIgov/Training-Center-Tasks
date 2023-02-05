using Newtonsoft.Json;

namespace Training_Center_Task_15
{
    public class ConsumerInfoReader
    {
        public static Consumer ReadSettings(string file)
        {
            Consumer consumer = new Consumer();
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                consumer = JsonConvert.DeserializeObject<Consumer>(json);
            }
            return consumer;
        }
    }
}
