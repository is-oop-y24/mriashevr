namespace Isu.Entities
{
    public class GroupName
    {
        public GroupName(string name)
        {
            GName = name;
            Specialty = name.Substring(0, 2);
            int item = int.Parse(name.Substring(2, 1));
            CourseNumber = new CourseNumber(item);
            GroupNumber = int.Parse(name.Substring(3, 2));
        }

        public string GName { get; }
        public string Specialty { get; }
        public CourseNumber CourseNumber { get; }
        public int GroupNumber { get; }
    }
}