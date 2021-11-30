using System.Collections.Generic;
using Backups.Entities;

namespace Backups.Services
{
    public interface IAlgorithm
    {
        List<Storage> ChooseYourAlgorithm(List<JobObject> jobObjects);
    }
}