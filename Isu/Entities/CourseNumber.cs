using System;

namespace Isu.Entities
{
    public class CourseNumber
    {
        public CourseNumber(int course)
        {
            Course = course;
        }

        public int Course { get; }
    }

    // public enum CourseNumber
    // {
    //     Fisrt = 1,
    //     Second = 2,
    //     Third = 3,
    //     Fourth = 4,
    // }
}