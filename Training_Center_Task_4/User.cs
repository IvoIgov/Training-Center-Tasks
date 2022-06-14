using System.Text;

namespace Training_Center_Task_4
{
    public class User
    {
        private string _name;
        private List<Window> _windows = new List<Window>();

        public User(string name)
        {
            this.Name = name;
            this.Windows = _windows;
        }

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
        public List<Window> Windows { get; set; }

        public static void PrintUserInfo(List<User> allUsers)
        {
            foreach (var user in allUsers)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Login: {user.Name}");
                foreach (var item in user.Windows)
                {
                    if (item.Title == "main")
                    {
                        sb.AppendLine($"  {item.Title}({item.Top}, {item.Left}, {item.Width}, {item.Height})");
                    }
                    else
                    {
                        sb.AppendLine($"  {item.Title}({item.Left}, {item.Top}, {Window.WindowDefaultPrint}, {item.Height})");
                    }
                }
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
