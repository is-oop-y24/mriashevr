using System;
using System.IO;
using System.Linq;
using System.Net;

namespace BackupsExtra.Logging
{
    public class FileLogging
    {
        public FileLogging()
        {
            Path = "../../../../Backups/Files/";
        }

        public string Path { get; }
        public void LogCreatedRestorePoint()
        {
            File.AppendAllText(Path, DateTime.Now + "You created restore point");
        }

        public void LogCreatedBackupJob()
        {
            File.AppendAllText(Path, DateTime.Now + "You created backup job");
        }

        public void LogDeletedBackupJob()
        {
            File.AppendAllText(Path, DateTime.Now + "You deleted backup job");
        }

        public void LogMerge()
        {
            File.AppendAllText(Path, DateTime.Now + "Merge is done");
        }

        public void LogAlgorithm()
        {
            File.AppendAllText(Path, DateTime.Now + "Algorithm is done");
        }
    }
}