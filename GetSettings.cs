using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_15
{
    public class GetSettings
    {
        public Item GetConfigFileData()
        {
            var setupSettings = ConfigReader.ReadSettings("Config\\Settings.json");
            return setupSettings;
        }
    }
}
