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
    }
}
