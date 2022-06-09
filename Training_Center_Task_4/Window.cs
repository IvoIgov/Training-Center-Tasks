namespace Training_Center_Task_4
{
    public class Window
    {
        private string _title;
        private int _top;
        private int _left;
        private int _width;
        private int _height;

        public const int HelpWindowDefaultWidth = 0;
        public const string HelpWindowWidthDefaultPrint = "?";

        public Window()
        {

        }
        public Window(string title, int top, int left, int width, int height)
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
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception(ExceptionMessages.WindowTitleCannotBeEmpty);
                }
                _title = value;
            }
        }

        public int Top
        {
            get { return _top; }
            set
            {
                if (value < 0)
                {
                    throw new Exception(ExceptionMessages.TopValueCannotBeNegative);
                }
                _top = value;
            }
        }


        public int Left
        {
            get { return _left; }
            set
            {
                if (value < 0)
                {
                    throw new Exception(ExceptionMessages.LeftValueCannotBeNegative);
                }
                _left = value;
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                if (value < 0)
                {
                    throw new Exception(ExceptionMessages.LeftValueCannotBeNegative);
                }
                _width = value;
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                {
                    throw new Exception(ExceptionMessages.HeightValueCannotBeNegative);
                }
                _height = value;
            }
        }        
    }
}
