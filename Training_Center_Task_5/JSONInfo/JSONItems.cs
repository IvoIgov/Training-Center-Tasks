using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_5.JSONInfo
{
    public class JSONItems
    {
        public string ListenerName { get; set; }
        public string MinimumLevel { get; set; }
        public string Name { get; set; }
        public List<Args> Args { get; set; }

    }
}
