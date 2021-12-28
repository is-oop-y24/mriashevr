using System;
using System.Collections.Generic;

namespace Backups.Entities
{
    public class RestorePoint
    {
        public RestorePoint()
        {
            DateCreate = DateTime.Now;
            NameDirectory = $"Directory-{IdGenerator.NewId()}";
            Storages = new List<Storage>();
        }

        public DateTime DateCreate { get; }
        public string NameDirectory { get; }
        public List<Storage> Storages { get; }
    }
}