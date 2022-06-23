using System.Text;
using Training_Center_Task_5;

namespace TextListener
{
    public class TextListeners : IListener
    {
        private const string FileExtension = "log.txt";

        //string path = String.Format(LogFilesPaths.TextFilePath, FileExtension);
        string path;

        public string CurrentDirectory { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public TextListeners()
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.txt";
            this.FilePath = CurrentDirectory + "/Logs/" + FileName;
        }

        public void StartLogger()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now);

                // flush every 20 seconds as you do it
                File.AppendAllText(FilePath, sb.ToString());
                sb.Clear();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now);

                // flush every 20 seconds as you do it
                File.AppendAllText(FilePath, sb.ToString());
                sb.Clear();
            }
        }
    }
}