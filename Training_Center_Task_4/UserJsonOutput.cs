using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_Center_Task_4
{
    public class UserJsonOutput
    {
        public string Username { get; set; }

        public string WindowTitleMain { get; set; }
        public string WindowTitleHelp { get; set; }

        public int MainTop { get; set; }

        public int MainLeft { get; set; }

        public int MainWidth { get; set; }

        public int MainHeight { get; set; }

        public int HelpTop { get; set; }

        public int HelpLeft { get; set; }

        public int HelpWidth { get; set; }

        public int HelpHeight { get; set; }
    }
}
