namespace Training_Center_Task_4
{
    public class Window
    {
        private string _title;
        private string _top;
        private string _left;
        private string _width;
        private string _height;

        public const string WindowDefaultWidth = "0";
        public const string WindowDefaultPrint = "?";

        public Window()
        {

        }
        public Window(string title, string top, string left, string width, string height)
        {
            this.Title = title;
            this.Top = top;
            this.Left = left;
            this.Width = width;
            this.Height = height;
        }

        public string Title
        {
            get { return _title; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception(ExceptionMessages.WindowTitleCannotBeEmpty);
                }
                _title = value;
            }
        }

        public string Top
        {
            get { return _top; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    value = WindowDefaultPrint;
                    _top = value;
                }
                else
                {
                    int a = 0;
                    bool successfullyParsed = int.TryParse(value, out a);
                    if (a < 0)
                    {
                        throw new Exception(ExceptionMessages.TopValueCannotBeNegative);
                    }
                    if (successfullyParsed)
                    {
                        _top = a.ToString();
                    }
                    else
                    {
                        _top = WindowDefaultPrint;
                    }
                }
            }
        }


        public string Left
        {
            get { return _left; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    value = WindowDefaultPrint;
                    _left = value;
                }
                else
                {
                    int a = 0;
                    bool successfullyParsed = int.TryParse(value, out a);
                    if (a < 0)
                    {
                        throw new Exception(ExceptionMessages.TopValueCannotBeNegative);
                    }
                    if (successfullyParsed)
                    {
                        _left = a.ToString();
                    }
                    else
                    {
                        _left = WindowDefaultPrint;
                    }
                }
            }
        }

        public string Width
        {
            get { return _width; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    value = WindowDefaultPrint;
                    _width = value;
                }
                else
                {
                    int a = 0;
                    bool successfullyParsed = int.TryParse(value, out a);
                    if (a < 0)
                    {
                        throw new Exception(ExceptionMessages.TopValueCannotBeNegative);
                    }
                    if (successfullyParsed)
                    {
                        _width = a.ToString();
                    }
                    else
                    {
                        _width = WindowDefaultPrint;
                    }
                }
            }
        }

        public string Height
        {
            get { return _height; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    value = WindowDefaultPrint;
                    _height = value;
                }
                else
                {
                    int a = 0;
                    bool successfullyParsed = int.TryParse(value, out a);
                    if (a < 0)
                    {
                        throw new Exception(ExceptionMessages.TopValueCannotBeNegative);
                    }
                    if (successfullyParsed)
                    {
                        _height = a.ToString();
                    }
                    else
                    {
                        _height = WindowDefaultPrint;
                    }
                }
            }
        }        
    }
}
