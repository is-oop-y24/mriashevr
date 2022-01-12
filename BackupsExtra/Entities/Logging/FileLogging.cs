using System;
using System.IO;
using System.Linq;
using System.Net;

namespace BackupsExtra.Logging
{
    public class FileLogging : ILogging
    {
        public FileLogging(string path)
        {
            Path = path;
        }

        public string Path { get; }
        public void Log(string message)
        {
            File.AppendAllText(Path, DateTime.Now + message);
        }
    }
}