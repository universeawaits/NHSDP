using System;


namespace NHSDP_Request_handling.WEB.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string information)
        {
            Console.WriteLine(information);
        }
    }
}
