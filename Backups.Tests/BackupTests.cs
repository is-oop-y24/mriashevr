using System.IO;
using Backups.Entities;
using Backups.Services;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupTests
    {
        private IRepository _repository;
        private BackupManager _backupManager;

        [SetUp]
        public void Setup()
        {
            _repository = new VirtualRepository(new DirectoryInfo("../../../../Backups/Backups"));
            _backupManager = new BackupManager(_repository);
        }

        [Test]
        public void CreateBackup()
        {
            JobObject jobObject1 = _backupManager.AddJobObject("../../../../Backups/Files/FileA");
            JobObject jobObject2 = _backupManager.AddJobObject("../../../../Backups/Files/FileB");
            _backupManager.CreateBackUp(new SplitStorage());
            _backupManager.RemoveJobObject(jobObject2);
            _backupManager.CreateBackUp(new SplitStorage());
            Assert.AreEqual(_backupManager.BackupJob.RestorePoints.Count, 2);
            
            int count = 0;
            foreach (RestorePoint restorePoint in _backupManager.BackupJob.RestorePoints)
            {
                count += restorePoint.Storages.Count;
            }
            Assert.AreEqual(count, 3);
        }
    }
}