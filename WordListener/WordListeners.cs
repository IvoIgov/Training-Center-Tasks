using System.Text;
using Training_Center_Task_5;

namespace WordListener
{
    public class WordListeners : IListener
    {
        private const string pathToLogs = @"C:\Users\IvoIgov\source\repos\Training_Center_Task_5\";
        private const string LogsFolderName = @"Logs\";

        //string path = String.Format(LogFilesPaths.WordFilePath, FileExtension);

        public string CurrentDirectory { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public WordListeners()
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.docx";
            this.FilePath = /*CurrentDirectory*/ pathToLogs + LogsFolderName + FileName;
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