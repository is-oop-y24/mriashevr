using System.Linq;
using Isu.Tools;

namespace Isu.Entities
{
    public class GroupName
    {
        public GroupName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new IsuException("name group eq null");
            }

            if (name.Count() > 5 || name.Count() < 5)
            {
                throw new IsuException("name group contains too many or too few letters");
            }

            if (name[0] != 'M')
                throw new IsuException("Invalid group name");

            Name = name;
            Specialty = name.Substring(0, 2);
            СourseNumber = (CourseNumber)int.Parse(name.Substring(2, 1));

            if (!int.TryParse(name.Substring(3, 2), out int groupNumber))
            {
                throw new IsuException("invalid");
            }

            if (groupNumber < 0 || groupNumber > 99)
            {
                throw new IsuException("invalid");
            }
        }

        public string Name { get; }
        public string Specialty { get; }
        public CourseNumber СourseNumber { get; }
    }
}