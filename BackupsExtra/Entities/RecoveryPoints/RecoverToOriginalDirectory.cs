using Backups.Entities;
using Ionic.Zip;

namespace BackupsExtra.RecoveryPoints
{
    public class RecoverToOriginalDirectory : IRecovery
    {
        public RestorePoint Recover(RestorePoint restorePoint, string prevdirectory)
        {
            foreach (var storage in restorePoint.Storages)
            {
                foreach (var jobObject in storage.ReservedJobObjects)
                {
                    var zip = new ZipFile();
                    string path = $@"{prevdirectory}/{IdGenerator.NewId()}.zip";
                    zip.AddFile(jobObject.Path, prevdirectory);
                    zip.Save(path);
                }
            }

            return restorePoint;
        }
    }
}