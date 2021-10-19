namespace IsuExtra.Entities
{
    public class Lesson
    {
        public Lesson(string subject, double time, int day, int classroom, string teacher)
        {
            Subject = subject;
            Time = time;
            WeekDay = day;
            ClassRoom = classroom;
            Teacher = teacher;
        }

        public string Subject { get; }
        public double Time { get; }
        public int ClassRoom { get; }
        public string Teacher { get; }
        public int WeekDay { get; }
    }
}