using System.IO;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Training_Center_Task_4;

using (XmlReader reader = XmlReader.Create(XMLReaderLinks.XMlFileLink))
{
    string windowName = string.Empty;
    List<int> windowData = new List<int>();
    User user = new User(string.Empty);
    List<User> allUsers = new List<User>();
    bool userAddedToList = false;
    while (reader.Read())
    {
        if (reader.IsStartElement())
        {
            if (reader.Name.ToString() == "login")
            {
                string userName = reader.GetAttribute("name");
                if (userAddedToList == true)
                {
                    user = new User(userName);
                    userAddedToList = false;
                }
            }
            else
            {
                switch (reader.Name.ToString())
                {
                    case "window":
                        windowName = reader.GetAttribute("title");
                        break;
                    case "top":
                        int top = int.Parse(reader.ReadString());
                        windowData.Add(top);
                        break;
                    case "left":
                        int left = int.Parse(reader.ReadString());
                        windowData.Add(left);
                        break;
                    case "width":
                        int width = int.Parse(reader.ReadString());
                        windowData.Add(width);
                        break;
                    case "height":
                        int height = int.Parse(reader.ReadString());
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
                userAddedToList = true;
                windowData = new List<int>();
                user = new User(string.Empty);
            }
        }
    }

    PrintUserInfo(allUsers);

    WriteUserWindowInfoToJSON(user);

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
    var xmlStr = File.ReadAllText(XMLReaderLinks.XMlFileLink);

    var str = XElement.Parse(xmlStr);

    var listUsers = str.Elements("login").ToList();

    foreach (var item in listUsers)
    {
        var serializer = new XmlSerializer(typeof(Window));
        var result = (Window)serializer.Deserialize(item.CreateReader());
    }

    //var UserJsonOutput = new UserJsonOutput()
    //{
    //    Username = listUsers.
    //}
}


