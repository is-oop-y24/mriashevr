using System.Collections.Generic;
using System.IO;

namespace Backups.Entities
{
    public interface IRepository
    {
        List<Storage> StartBackUp(List<Storage> storages, string newDirectory);
        void CreateDirectory(string directoryName);
    }
}