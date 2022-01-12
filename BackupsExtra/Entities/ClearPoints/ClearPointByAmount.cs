using System;
using System.Collections.Generic;
using System.Linq;
using Backups.Entities;

namespace BackupsExtra
{
    public class ClearPointByAmount : IClearPoints
    {
        public List<RestorePoint> Clear(List<RestorePoint> restorePoints, DateTime? time, int? amount)
        {
            while (restorePoints.Count > amount)
            {
                for (int i = restorePoints.Count; i > amount; i--)
                {
                    var x = restorePoints.First();
                    restorePoints.Remove(x);
                }
            }

            return restorePoints;
        }
    }
}