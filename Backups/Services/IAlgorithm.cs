using System.Collections.Generic;
using Backups.Entities;

namespace Backups.Services
{
    public interface IAlgorithm
    {
        List<Storage> CreateStorages(List<JobObject> jobObjects);
    }
}