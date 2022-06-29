using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_5
{
    [TrackingEntity]
    public class SampleClass
    {
        [TrackingProperty]
        public string Name { get; set; }
        public string Description { get; set; }

        [TrackingProperty]
        public int Notes { get; set; }

        public SampleClass(string name, string description, int notes)
        {
            Name = name;
            Description = description;
            Notes = notes;
        }
    }
}
