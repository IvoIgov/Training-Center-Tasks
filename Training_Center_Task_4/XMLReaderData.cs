namespace Training_Center_Task_4
{
    public class XMLReaderLinks
    {
        public const string XMlFileLink = @"C:\Users\IvoIgov\source\repos\Training_Center_Task_4\WindowData.txt";

        public static void WriteJSONDataToFile(string path, string JSONResult)
        {
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONResult.ToString());
                tw.Close();
            }
        }
    }
}
