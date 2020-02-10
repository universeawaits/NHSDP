using System.IO;


namespace NHSDP_Request_handling.WEB.Logging
{
    public class FileLogger : ILogger
    {
        public string FilePath { get; set; }

        public void Log(string information)
        {
            using (var writer = File.AppendText(FilePath))
            {
                writer.WriteLine(information);
            }
        }
    }
}
