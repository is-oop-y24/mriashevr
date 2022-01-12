using System;
using System.Collections.Generic;
using Backups.Entities;

namespace BackupsExtra
{
    public interface IClearPoints
    {
        List<RestorePoint> Clear(List<RestorePoint> restorePoints, DateTime? time, int? amount);
    }
}