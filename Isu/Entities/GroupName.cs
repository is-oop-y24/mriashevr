namespace Isu.Entities
{
    public class GroupName
    {
        public GroupName(string name)
        {
            GName = name;
            Specialty = name.Substring(0, 2);
            СourseNumber = (CourseNumber)int.Parse(name.Substring(2, 1));
            GroupNumber = int.Parse(name.Substring(3, 2));
        }

        public string GName { get; }
        public string Specialty { get; }
        public CourseNumber СourseNumber { get; }
        public int GroupNumber { get; }
    }
}