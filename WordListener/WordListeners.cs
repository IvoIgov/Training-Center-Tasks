using System.Text;
using Training_Center_Task_5;
using Training_Center_Task_5.JSONInfo;

namespace WordListener
{
    public class WordListeners : IListener
    {
        private const string pathToLogs = LogFilesPaths.WordFilePath;


        //string path = String.Format(LogFilesPaths.WordFilePath, FileExtension);

        public string CurrentDirectory { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public WordListeners()
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = LogFilesPaths.WordFileName; ;
            this.FilePath = /*CurrentDirectory*/ pathToLogs;
        }

        public void LogMessage(string message)
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(message);

            File.AppendAllText(FilePath, sb.ToString());
            sb.Clear();
        }
    }
}