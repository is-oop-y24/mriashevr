using System;
using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra
{
    public class ClearPointsStrict : IClearPoints
    {
        public List<RestorePoint> Clear(List<RestorePoint> restorePoints, DateTime? time, int? amount)
        {
            for (int i = 0; i < restorePoints.Count; i++)
            {
                if (restorePoints[i].DateCreate > time || restorePoints.Count > amount)
                {
                    restorePoints.Remove(restorePoints[i]);
                }
            }

            return restorePoints;
        }
    }
}