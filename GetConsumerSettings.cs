namespace Training_Center_Task_15
{
    public class GetConsumerSettings
    {
        public Consumer GetPrimaryConsumerFileData()
        {
            var primaryConsumerSettings = ConsumerInfoReader.ReadSettings("Config\\PrimaryUserInfo.json");
            return primaryConsumerSettings;
        }
        public Consumer GetNewConsumerFileData()
        {
            var newConsumerSettings = ConsumerInfoReader.ReadSettings("Config\\NewUserInfo.json");
            return newConsumerSettings;
        }
    }
}
