using System.Text;

namespace WordListener
{
    public class WordListeners
    {
        private const string LogsFolderName = "/Logs/";

        //string path = String.Format(LogFilesPaths.WordFilePath, FileExtension);

        public string CurrentDirectory { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public WordListeners()
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.docx";
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