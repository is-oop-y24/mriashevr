using System.Collections.Generic;
using Backups.Entities;

namespace Backups.Services
{
    public class BackupManager
    {
        public BackupManager(Repository repository)
        {
            Repository = repository;
            BackupJob = new BackupJob();
        }

        public Repository Repository { get; }
        public BackupJob BackupJob { get; }
        public JobObject AddJobObject(string path)
        {
            var jobObject = new JobObject(path);
            BackupJob.AddJobObject(jobObject);
            return jobObject;
        }

        public void RemoveJobObject(JobObject jobObject)
        {
            BackupJob.RemoveJobObject(jobObject);
        }

        public void CreateLocalBackup(IAlgorithm algorithm)
        {
            var restorePoint = new RestorePoint();
            Repository.CreateDirectory(restorePoint.NameDirectory);
            List<Storage> storages = algorithm.CreateStorages(BackupJob.JobObjects);
            List<Storage> newStorages = Repository.StartLocalBackup(storages, restorePoint.NameDirectory);
            restorePoint.Storages.AddRange(newStorages);
            BackupJob.RestorePoints.Add(restorePoint);
        }
    }
}