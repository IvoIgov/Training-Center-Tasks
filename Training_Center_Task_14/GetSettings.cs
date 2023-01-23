namespace Training_Center_Task_14
{
    public class GetSettings
    {
        public Item GetItem()
        {
            string file = GetConfigFile();
            var setupSettings = ConfigReader.Read(file);

            return setupSettings;
        }

        private string GetConfigFile()
        {

            var setupSettings = ConfigReader.Read("Config\\Settings.json");
            string file = "";

            switch (setupSettings.platformName)
            {

                case "MacOS":
                    file = "Config\\Settings.Mac.json";
                    break;
                case "Windows 10":
                    file = "Config\\Settings.Win10.json";
                    break;
                case "Windows 8":
                    file = "Config\\Settings.Win8.json";
                    break;
                default:
                    Console.WriteLine($"File with {setupSettings.platformName} name wasn't found");
                    break;
            }


            return file;
        }

        public string PlatformName { get; set; }
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }
    }
}
