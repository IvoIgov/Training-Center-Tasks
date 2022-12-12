using Newtonsoft.Json;
using System.Reflection;

namespace Training_Center_Task_11.Models
{
    public class AccessJsonData
    {
        private static List<JsonDataPattern> _items = new List<JsonDataPattern>();

        public static JsonDataPattern GetTestData(string testName)
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativePathToJSON = @"..\..\..\..\Training_Center_Task_11\DDT\TestData.json";
            var fullPathToJSON = Path.GetFullPath(Path.Combine(outputDirectory, relativePathToJSON));
            using (StreamReader r = new StreamReader(fullPathToJSON))
            {
                string json = r.ReadToEnd();
                _items = JsonConvert.DeserializeObject<List<JsonDataPattern>>(json);
            }
            JsonDataPattern result = new JsonDataPattern();

            foreach (var item in _items)
            {
                if (item.TestName == testName)
                {
                    result.UserUsername = item.UserUsername;
                    result.UserPassword = item.UserPassword;
                }
            }
            return result;
        }
    }
}
