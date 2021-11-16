using System;

namespace IsuExtra.Entities
{
    public class Lesson
    {
        public Lesson(string subject, DateTime time, int classroom, string teacher)
        {
            Subject = subject;
            Time = time;
            ClassRoom = classroom;
            Teacher = teacher;
        }

        public string Subject { get; }
        public DateTime Time { get; }
        public int ClassRoom { get; }
        public string Teacher { get; }
    }
}