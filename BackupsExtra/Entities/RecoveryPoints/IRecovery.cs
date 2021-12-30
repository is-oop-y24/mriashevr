using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra.RecoveryPoints
{
    public interface IRecovery
    {
        RestorePoint Recover(RestorePoint restorePoints, string prevdirectory);
    }
}