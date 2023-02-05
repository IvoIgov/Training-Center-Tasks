namespace Training_Center_Task_15
{
    public class GetSettings
    {
        public Item GetConfigFileData()
        {
            var setupSettings = ConfigReader.ReadSettings("Config\\Settings.json");
            return setupSettings;
        }
    }
}
