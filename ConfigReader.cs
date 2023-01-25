using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_15
{
    public class ConfigReader
    {
        private static StreamReader _streamReader;
        public static Item ReadSettings(string file)
        {
            Item items = new Item();
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<Item>(json);
            }
            return items;
        }
    }
}
