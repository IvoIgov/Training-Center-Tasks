using Newtonsoft.Json;

namespace Training_Center_Task_7.Models
{
    public class AccessJsonData
    {
        private static string _jsonPath = Constants.PathToTestDataJSON;
        private static List<JsonDataPattern> _items = new List<JsonDataPattern>();

        public static JsonDataPattern GetTestData(string testName)
        {
            using (StreamReader r = new StreamReader(_jsonPath))
            {
                string json = r.ReadToEnd();
                _items = JsonConvert.DeserializeObject<List<JsonDataPattern>>(json);
            }
            JsonDataPattern result = new JsonDataPattern();

            foreach (var item in _items)
            {
                if (item.TestName == testName)
                {
                    result.User1Username = item.User1Username;
                    result.User1Password = item.User1Password;
                    result.User2Username = item.User2Username;
                    result.User2Password = item.User2Password;
                    result.EmailTo = item.EmailTo;
                    result.EmailSubject = item.EmailSubject;
                    result.EmailText = item.EmailText;
                }
            }
            return result;
        }
    }
}
