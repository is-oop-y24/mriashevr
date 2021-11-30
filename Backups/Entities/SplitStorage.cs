using System.Collections.Generic;
using Backups.Services;

namespace Backups.Entities
{
    public class SplitStorage : IAlgorithm
    {
        public List<Storage> ChooseYourAlgorithm(List<JobObject> jobObjects)
        {
            var storages = new List<Storage>();
            foreach (JobObject jobObject in jobObjects)
            {
                var list = new List<JobObject>();
                list.Add(jobObject);
                var storage = new Storage(list);
                storages.Add(storage);
            }

            return storages;
        }
    }
}