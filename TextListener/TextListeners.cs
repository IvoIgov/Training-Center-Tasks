using System.Text;
using Training_Center_Task_5;

namespace TextListener
{
    public class TextListeners : IListener
    {
        private const string LogsFolderName = "/Logs/";

        //string path = String.Format(LogFilesPaths.TextFilePath, FileExtension);

        public string CurrentDirectory { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public TextListeners()
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.txt";
            this.FilePath = CurrentDirectory + LogsFolderName + FileName;
        }

        public void LogMessage(string message)
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(message);

            // flush every 20 seconds as you do it
            File.AppendAllText(FilePath, sb.ToString());
            sb.Clear();
        }
    }
}
