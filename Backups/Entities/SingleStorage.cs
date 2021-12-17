using System.Collections.Generic;
using Backups.Services;

namespace Backups.Entities
{
    public class SingleStorage : IAlgorithm
    {
        public List<Storage> CreateStorages(List<JobObject> jobObjects)
        {
            var storages = new List<Storage>();
            storages.Add(new Storage(jobObjects));
            return storages;
        }
    }
}