using System.Collections.Generic;
using System.Linq;
using Backups.Entities;

namespace BackupsExtra
{
    public class Merge
    {
        public List<RestorePoint> MergeToLast(List<RestorePoint> restorePoints)
        {
            RestorePoint restorePoint = restorePoints.Last();
            foreach (RestorePoint point in restorePoints)
            {
                foreach (Storage storage in point.Storages)
                {
                    if (!restorePoint.Storages.Contains(storage))
                    {
                        restorePoint.Storages.Add(storage);
                    }
                }
            }

            return restorePoints;
        }

        public List<RestorePoint> DeleteRestorePoint(List<RestorePoint> restorePoints)
        {
            RestorePoint restorePoint = restorePoints.Last();
            foreach (RestorePoint point in restorePoints)
            {
                foreach (Storage storage in point.Storages)
                {
                    if (restorePoint.Storages.Contains(storage))
                    {
                        point.Storages.Remove(storage);
                    }
                }
            }

            return restorePoints;
        }

        public List<RestorePoint> DeleteSingleStored(List<RestorePoint> restorePoints)
        {
            for (int i = 0; i < restorePoints.Count; i++)
            {
                if (restorePoints[i].Storages.Count == 1)
                {
                    restorePoints.Remove(restorePoints[i]);
                }
            }

            return restorePoints;
        }
    }
}