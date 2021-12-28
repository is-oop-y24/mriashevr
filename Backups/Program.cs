using System.IO;
using Backups.Entities;
using Backups.Services;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            IRepository repository = new LocalRepository(new DirectoryInfo("../../../Backups"));

            // var repository = new Repository(new DirectoryInfo("../../../Backups"));
            var backupManager = new BackupManager(repository);
            backupManager.AddJobObject("../../../Files/FileA");
            backupManager.AddJobObject("../../../Files/FileB");
            backupManager.CreateBackUp(new SingleStorage());
        }
    }
}
