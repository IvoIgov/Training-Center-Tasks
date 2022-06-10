using Newtonsoft.Json;
using System.Text;
using System.Xml;
using Training_Center_Task_4;

using (XmlReader reader = XmlReader.Create(XMLReaderLinks.XMlFileLink))
{
    string windowName = string.Empty;
    List<int> windowData = new List<int>();
    User user = new User(string.Empty);
    List<User> allUsers = new List<User>();
    //bool userAddedToList = false;
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
                        int top = 0;
                        try
                        {
                            top = int.Parse(reader.ReadString());
                        }
                        catch (Exception ex)
                        {
                        }
                        windowData.Add(top);
                        break;
                    case "left":
                        int left = 0;
                        try
                        {
                            left = int.Parse(reader.ReadString());
                        }
                        catch (Exception ex)
                        {
                        }
                        windowData.Add(left);
                        break;
                    case "width":
                        int width = 400;
                        try
                        {
                            width = int.Parse(reader.ReadString());
                        }
                        catch (Exception ex)
                        {
                        }
                        windowData.Add(width);
                        break;
                    case "height":
                        int height = 150;
                        try
                        {
                            height = int.Parse(reader.ReadString());
                        }
                        catch (Exception ex)
                        {
                        }
                        windowData.Add(height);
                        break;
                }
            }
            if (windowName == "main" && windowData.Count == 4)
            {
                Window mainWindow = new Window(windowName, windowData[0], windowData[1], windowData[2], windowData[3]);
                user.Windows.Add(mainWindow);
                windowData = new List<int>();
            }
            if (windowName == "help" && windowData.Count == 3)
            {
                Window helpWindow = new Window(windowName, windowData[1], windowData[0], Window.HelpWindowDefaultWidth, windowData[2]);
                user.Windows.Add(helpWindow);
                allUsers.Add(user);

                //Write user info to JSON file
                WriteUserWindowInfoToJSON(user);

                //userAddedToList = true;
                windowData = new List<int>();
                user = new User(string.Empty);

            }
        }
    }

    PrintUserInfo(allUsers);

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
        Window helpWindow = new Window(user.Windows[1].Title, user.Windows[1].Top, user.Windows[1].Left, Window.HelpWindowDefaultWidth, user.Windows[1].Height);
        return helpWindow;
    }
}

void PrintUserInfo(List<User> allUsers)
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
                sb.AppendLine($"  {item.Title}({item.Left}, {item.Top}, {Window.HelpWindowWidthDefaultPrint}, {item.Height})");
            }
        }
        Console.WriteLine(sb.ToString().TrimEnd());
    }
}

void WriteUserWindowInfoToJSON(User user)
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


