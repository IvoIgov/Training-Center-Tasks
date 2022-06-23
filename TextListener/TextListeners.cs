using System.Text;
using Training_Center_Task_5;

namespace TextListener
{
    public class TextListeners : IListener
    {
        private const string FileExtension = "log.txt";

        string path = String.Format(LogFilesPaths.TextFilePath, FileExtension);

        public void StartLogger()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now);

                // flush every 20 seconds as you do it
                File.AppendAllText(path, sb.ToString());
                sb.Clear();
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DateTime.Now);

                // flush every 20 seconds as you do it
                File.AppendAllText(path, sb.ToString());
                sb.Clear();
            }
        }
    }
}