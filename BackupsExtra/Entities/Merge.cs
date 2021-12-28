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
            RestorePoint restorePoint = restorePoints.Last();
            foreach (RestorePoint point in restorePoints)
            {
                if (point.Storages.Count == 0 && point != restorePoint)
                {
                    restorePoints.Remove(point);
                }
            }

            return restorePoints;
        }
    }
}