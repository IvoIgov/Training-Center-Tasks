namespace Training_Center_Task_15
{
    public class NewConsumer
    {
        protected string dateTimeNow = DateTime.Now.ToString();

        public Consumer GenerateNewConsumer()
        {
            var reader = new GetConsumerSettings();
            var newConsumerSettings = reader.GetNewConsumerFileData();

            var consumer = new Consumer();
            {
                consumer.Username = newConsumerSettings.Username + dateTimeNow;
                consumer.Domain = newConsumerSettings.Domain;
                consumer.Email = consumer.Username.Replace(" ", "").Replace(":", "") + consumer.Domain;
                consumer.FirstName = consumer.Username + newConsumerSettings.FirstName;
                consumer.LastName = consumer.Username + newConsumerSettings.LastName;
                consumer.Password = newConsumerSettings.Password;
                consumer.Address = newConsumerSettings.Address;
                consumer.Country = newConsumerSettings.Country;
                consumer.State = newConsumerSettings.State;
                consumer.City = newConsumerSettings.City;
                consumer.Zipcode = newConsumerSettings.Zipcode;
                consumer.MobileNumber = newConsumerSettings.MobileNumber;
            };

            return consumer;
        }
    }
}
