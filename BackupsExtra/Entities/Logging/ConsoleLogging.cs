using System;

namespace BackupsExtra.Logging
{
    public class ConsoleLogging : ILogging
    {
        public void Log(string message)
        {
            Console.WriteLine(DateTime.Now + message);
        }
    }
}