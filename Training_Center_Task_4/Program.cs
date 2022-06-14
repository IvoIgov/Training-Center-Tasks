using System.Xml;
using Training_Center_Task_4;

using (XmlReader reader = XmlReader.Create(XMLReaderLinks.XMlFileLink))
{
    string windowName = string.Empty;
    List<string> windowData = new List<string>();
    User user = new User(string.Empty);
    List<User> allUsers = new List<User>();

    while (reader.Read())
    {
        if (reader.IsStartElement())
        {
            if (reader.Name.ToString() == "login")
            {
                string userName = reader.GetAttribute("name");
                user = new User(userName);
            }
            else
            {
                switch (reader.Name.ToString())
                {
                    case "window":
                        windowName = reader.GetAttribute("title");
                        break;
                    case "top":
                        string top = reader.ReadString();
                        windowData.Add(top);
                        break;
                    case "left":
                        string left = reader.ReadString();
                        windowData.Add(left);
                        break;
                    case "width":
                        string width = reader.ReadString();
                        windowData.Add(width);
                        break;
                    case "height":
                        string height = reader.ReadString();
                        windowData.Add(height);
                        break;
                }
            }
            if (windowName == "main" && windowData.Count == 4)
            {
                Window mainWindow = new Window(windowName, windowData[0], windowData[1], windowData[2], windowData[3]);
                user.Windows.Add(mainWindow);
                windowData = new List<string>();
            }
            if (windowName == "help" && windowData.Count == 3)
            {
                Window helpWindow = new Window(windowName, windowData[1], windowData[0], Window.WindowDefaultPrint, windowData[2]);
                user.Windows.Add(helpWindow);
                allUsers.Add(user);

                //Write user info to JSON file
                UserJsonOutput.WriteUserWindowInfoToJSON(user);

                windowData = new List<string>();
                user = new User(string.Empty);
            }
        }
    }

    User.PrintUserInfo(allUsers);

    var username = Console.ReadLine();
    var password = Console.ReadLine();
    Window window = LoginWindow(allUsers, username, password);
}


Window LoginWindow(List<User> allUsers, string username, string password)
{
    User user = allUsers.FindAll(x => x.Name == username).FirstOrDefault();

    if (password == "123")
    {
        Window mainWindow = new Window(user.Windows[0].Title, user.Windows[0].Top, user.Windows[0].Left, user.Windows[0].Width, user.Windows[0].Height);
        return mainWindow;
    }
    else
    {
        Window helpWindow = new Window(user.Windows[1].Title, user.Windows[1].Top, user.Windows[1].Left, Window.WindowDefaultWidth, user.Windows[1].Height);
        return helpWindow;
    }
}


