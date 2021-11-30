using System.IO;
using Backups.Entities;
using Backups.Services;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var repository = new Repository(new DirectoryInfo("../../../Backups"));
            var backupManager = new BackupManager(repository);
            backupManager.AddJobObject("../../../Files/FileA");
            backupManager.AddJobObject("../../../Files/FileB");
            backupManager.CreateLocalBackup(new SingleStorage());
        }
    }
}
