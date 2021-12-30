using System;
using System.IO;
using Backups.Entities;
using Backups.Services;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    public class BackupsExtraTests
    {
        // private IRepository _repository;
        // private BackupManager _backupManager;
        // private Merge _merge;
        // private IClearPoints _clear;
        // private IClearPoints _clearPoints;
        //
        // [SetUp]
        // public void Setup()
        // {
        //     _repository = new VirtualRepository(new DirectoryInfo("../../../../Backups/Backups"));
        //     _backupManager = new BackupManager(_repository);
        //     _merge = new Merge();
        //     _clear = new ClearPointByAmount();
        //     _clearPoints = new ClearPointsStrict();
        // }
        //
        // [Test]
        // public void DeleteSingleStoredPoints()
        // {
        //     JobObject jobObject1 = _backupManager.AddJobObject("../../../../Backups/Files/FileA");
        //     JobObject jobObject2 = _backupManager.AddJobObject("../../../../Backups/Files/FileB");
        //     JobObject jobObject3 = _backupManager.AddJobObject("../../../../Backups/Files/FileA");
        //     JobObject jobObject4 = _backupManager.AddJobObject("../../../../Backups/Files/FileB");
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _backupManager.CreateBackUp(new SingleStorage());
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _backupManager.CreateBackUp(new SingleStorage());
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _backupManager.CreateBackUp(new SingleStorage());
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _merge.DeleteSingleStored(_backupManager.BackupJob.RestorePoints);
        //     Assert.AreEqual(4, _backupManager.BackupJob.RestorePoints.Count);
        // }
        //
        // [Test]
        // public void ClearPointsByAmount()
        // {
        //     JobObject jobObject1 = _backupManager.AddJobObject("../../../../Backups/Files/FileA");
        //     JobObject jobObject2 = _backupManager.AddJobObject("../../../../Backups/Files/FileB");
        //     JobObject jobObject3 = _backupManager.AddJobObject("../../../../Backups/Files/FileA");
        //     JobObject jobObject4 = _backupManager.AddJobObject("../../../../Backups/Files/FileB");
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _backupManager.CreateBackUp(new SingleStorage());
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _backupManager.CreateBackUp(new SingleStorage());
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _backupManager.CreateBackUp(new SingleStorage());
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _clear.Clear(_backupManager.BackupJob.RestorePoints, null, 4);
        //     Assert.AreEqual(4, _backupManager.BackupJob.RestorePoints.Count);
        // }
        //
        // [Test]
        // public void StrictClearByTimeAndAmount()
        // {
        //     JobObject jobObject1 = _backupManager.AddJobObject("../../../../Backups/Files/FileA");
        //     JobObject jobObject2 = _backupManager.AddJobObject("../../../../Backups/Files/FileB");
        //     JobObject jobObject3 = _backupManager.AddJobObject("../../../../Backups/Files/FileA");
        //     JobObject jobObject4 = _backupManager.AddJobObject("../../../../Backups/Files/FileB");
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _backupManager.CreateBackUp(new SingleStorage());
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _backupManager.CreateBackUp(new SingleStorage());
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _backupManager.CreateBackUp(new SingleStorage());
        //     _backupManager.CreateBackUp(new SplitStorage());
        //     _clearPoints.Clear(_backupManager.BackupJob.RestorePoints, DateTime.Now, 3);
        //     Assert.AreEqual(3, _backupManager.BackupJob.RestorePoints.Count);
        // }
    }
}