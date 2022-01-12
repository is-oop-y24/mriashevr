using System;
using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra
{
    public class ClearPointsNotStrict : IClearPoints
    {
        public List<RestorePoint> Clear(List<RestorePoint> restorePoints, DateTime? time, int? amount)
        {
            foreach (RestorePoint restorePoint in restorePoints)
            {
                if (restorePoint.DateCreate > time && restorePoints.Count > amount)
                {
                    restorePoints.Remove(restorePoint);
                }
            }

            return restorePoints;
        }
    }
}