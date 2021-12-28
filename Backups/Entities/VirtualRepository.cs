using System.Collections.Generic;
using System.IO;

namespace Backups.Entities
{
    public class VirtualRepository : IRepository
    {
        public VirtualRepository(DirectoryInfo directory)
        {
            DirectoryPath = directory;
        }

        public DirectoryInfo DirectoryPath { get; }

        public void CreateDirectory(string directoryName)
        {
            Directory.CreateDirectory($"{DirectoryPath}/{directoryName}");
        }

        public List<Storage> StartBackUp(List<Storage> localStorages, string newDirectory)
        {
            var newStorages = new List<Storage>();
            foreach (Storage storage in localStorages)
            {
                var newStorage = new Storage();
                foreach (JobObject jobObject in storage.ReservedJobObjects)
                {
                    string jobObjectName = jobObject.Path.Substring(jobObject.Path.LastIndexOf('/') + 1);
                    string newpath = $@"{DirectoryPath.FullName}/{newDirectory}/{jobObjectName}.zip";
                    var newJobObject = new JobObject(newpath);
                    newStorage.ReservedJobObjects.Add(newJobObject);
                }

                newStorages.Add(newStorage);
            }

            return newStorages;
        }
    }
}