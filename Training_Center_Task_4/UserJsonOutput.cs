namespace Training_Center_Task_4
{
    public class UserJsonOutput
    {
        private string _name;
        private string _windowTitleMain;
        private string _mainTop;
        private string _mainLeft;
        private string _mainWidth;
        private string _mainHeight;
        private string _windowTitleHelp;
        private string _helpTop;
        private string _helpLeft;
        private string _helpWidth;
        private string _helpHeight;

        private const string DefaultXMLValue = "?";
        private const string TopDefaultValue = "0";
        private const string LeftDefaultValue = "0";
        private const string WidthDefaultValue = "400";
        private const string HeightDefaultValue = "150";
        public string Name { get; set; }

        public string WindowTitleMain { get; set; }

        public string MainTop
        {
            get { return _mainTop; }
            set
            {
                if (value == DefaultXMLValue)
                {
                    value = TopDefaultValue;
                }
                _mainTop = value;
            }
        }

        public string MainLeft
        {
            get { return _mainLeft; }
            set
            {
                if (value == DefaultXMLValue)
                {
                    value = LeftDefaultValue;
                }
                _mainLeft = value;
            }
        }

        public string MainWidth
        {
            get { return _mainWidth; }
            set
            {
                if (value == DefaultXMLValue)
                {
                    value = WidthDefaultValue;
                }
                _mainWidth = value;
            }
        }

        public string MainHeight
        {
            get { return _mainHeight; }
            set
            {
                if (value == DefaultXMLValue)
                {
                    value = HeightDefaultValue;
                }
                _mainHeight = value;
            }
        }

        public string WindowTitleHelp { get; set; }

        public string HelpTop
        {
            get { return _helpTop; }
            set
            {
                if (value == DefaultXMLValue)
                {
                    value = TopDefaultValue;
                }
                _helpTop = value;
            }
        }

        public string HelpLeft
        {
            get { return _helpLeft; }
            set
            {
                if (value == DefaultXMLValue)
                {
                    value = LeftDefaultValue;
                }
                _helpLeft = value;
            }
        }

        public string HelpWidth
        {
            get { return _helpWidth; }
            set
            {
                if (value == DefaultXMLValue)
                {
                    value = WidthDefaultValue;
                }
                _helpWidth = value;
            }
        }

        public string HelpHeight
        {
            get { return _helpHeight; }
            set
            {
                if (value == DefaultXMLValue)
                {
                    value = HeightDefaultValue;
                }
                _helpHeight = value;
            }
        }
    }
}
