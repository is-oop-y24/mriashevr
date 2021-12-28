using System.Collections.Generic;

namespace Backups.Entities
{
    public class Storage
    {
        public Storage()
        {
            ReservedJobObjects = new List<JobObject>();
        }

        public Storage(List<JobObject> jobObjects)
        {
            ReservedJobObjects = jobObjects;
        }

        public List<JobObject> ReservedJobObjects { get; }
    }
}