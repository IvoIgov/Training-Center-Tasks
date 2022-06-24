using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
