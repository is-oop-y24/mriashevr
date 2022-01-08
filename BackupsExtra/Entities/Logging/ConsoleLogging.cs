using System;

namespace BackupsExtra.Logging
{
    public class ConsoleLogging : ILogging
    {
        public void LogCreatedRestorePoint()
        {
            Console.WriteLine(DateTime.Now + "You created restore point");
        }

        public void LogCreatedBackupJob()
        {
            Console.WriteLine(DateTime.Now + "You created backup job");
        }

        public void LogDeletedBackupJob()
        {
            Console.WriteLine(DateTime.Now + "You deleted backup job");
        }

        public void LogMerge()
        {
            Console.WriteLine(DateTime.Now + "Merge is done");
        }

        public void LogAlgorithm()
        {
            Console.WriteLine(DateTime.Now + "Algorithm is done");
        }
    }
}