using System.Collections.Generic;

namespace Backups.Entities
{
    public class BackupJob
    {
        public BackupJob() // в конструктор убрать алгоритм хранения интерфейсом, два варианта репозитория, ш репозит и ш алгоритм все надо кинуть в конструктор к бекапджобу
        {
            JobObjects = new List<JobObject>();
            RestorePoints = new List<RestorePoint>();
        } // все добавить в бекапджоб, ту он будет знать обо всем виртуал или нет сингл или сплит

        public List<JobObject> JobObjects { get; }
        public List<RestorePoint> RestorePoints { get; }

        public void AddJobObject(JobObject jobObject)
        {
            JobObjects.Add(jobObject);
        }

        public void RemoveJobObject(JobObject jobObject)
        {
            JobObjects.Remove(jobObject);
        }
    }
}