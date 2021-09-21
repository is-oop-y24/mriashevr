namespace Isu.Entities
{
    public class Student
    {
        private static int _id;

        public Student(string name)
        {
            Name = name;
            Id = (++_id) + 100000;
        }

        public string Name { get; }
        public int Id { get; }
}
}