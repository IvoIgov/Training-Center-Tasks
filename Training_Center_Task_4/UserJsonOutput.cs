using Newtonsoft.Json;

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


        public string Name
        {
            get { return _name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception(ExceptionMessages.UsernameCannotBeEmpty);
                }
                _name = value;
            }
        }

        public string WindowTitleMain
        {
            get { return _windowTitleMain; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception(ExceptionMessages.WindowTitleCannotBeEmpty);
                }
                _windowTitleMain = value;
            }
        }

        public string MainTop
        {
            get { return _mainTop; }
            set
            {
                if (value == JSONDataClass.DefaultXMLValue)
                {
                    value = JSONDataClass.TopDefaultValue;
                }
                _mainTop = value;
            }
        }

        public string MainLeft
        {
            get { return _mainLeft; }
            set
            {
                if (value == JSONDataClass.DefaultXMLValue)
                {
                    value = JSONDataClass.LeftDefaultValue;
                }
                _mainLeft = value;
            }
        }

        public string MainWidth
        {
            get { return _mainWidth; }
            set
            {
                if (value == JSONDataClass.DefaultXMLValue)
                {
                    value = JSONDataClass.WidthDefaultValue;
                }
                _mainWidth = value;
            }
        }

        public string MainHeight
        {
            get { return _mainHeight; }
            set
            {
                if (value == JSONDataClass.DefaultXMLValue)
                {
                    value = JSONDataClass.HeightDefaultValue;
                }
                _mainHeight = value;
            }
        }

        public string WindowTitleHelp
        {
            get { return _windowTitleHelp; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception(ExceptionMessages.WindowTitleCannotBeEmpty);
                }
                _windowTitleHelp = value;
            }
        }

        public string HelpTop
        {
            get { return _helpTop; }
            set
            {
                if (value == JSONDataClass.DefaultXMLValue)
                {
                    value = JSONDataClass.TopDefaultValue;
                }
                _helpTop = value;
            }
        }

        public string HelpLeft
        {
            get { return _helpLeft; }
            set
            {
                if (value == JSONDataClass.DefaultXMLValue)
                {
                    value = JSONDataClass.LeftDefaultValue;
                }
                _helpLeft = value;
            }
        }

        public string HelpWidth
        {
            get { return _helpWidth; }
            set
            {
                if (value == JSONDataClass.DefaultXMLValue)
                {
                    value = JSONDataClass.WidthDefaultValue;
                }
                _helpWidth = value;
            }
        }

        public string HelpHeight
        {
            get { return _helpHeight; }
            set
            {
                if (value == JSONDataClass.DefaultXMLValue)
                {
                    value = JSONDataClass.HeightDefaultValue;
                }
                _helpHeight = value;
            }
        }

        public static void WriteUserWindowInfoToJSON(User user)
        {
            UserJsonOutput jsonData = new UserJsonOutput();

            jsonData.Name = user.Name;

            jsonData.WindowTitleMain = user.Windows[0].Title;
            jsonData.MainTop = user.Windows[0].Top;
            jsonData.MainLeft = user.Windows[0].Left;
            jsonData.MainWidth = user.Windows[0].Width;
            jsonData.MainHeight = user.Windows[0].Height;

            jsonData.WindowTitleHelp = user.Windows[1].Title;
            jsonData.HelpTop = user.Windows[1].Top;
            jsonData.HelpLeft = user.Windows[1].Left;
            jsonData.HelpWidth = user.Windows[1].Width;
            jsonData.HelpHeight = user.Windows[1].Height;

            string JSONResult = JsonConvert.SerializeObject(jsonData);

            string path = String.Format(JSONDataClass.JSONFileLink, user.Name);

            if (File.Exists(path))
            {
                File.Delete(path);
                XMLReaderLinks.WriteJSONDataToFile(path, JSONResult);
            }
            else
            {
                XMLReaderLinks.WriteJSONDataToFile(path, JSONResult);
            }
        }
    }
}
