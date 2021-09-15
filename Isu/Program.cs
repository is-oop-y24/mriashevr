using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Isu.Entities;
using Isu.Services;

namespace Isu
{
    internal class Program
    {
        private static void Main()
        {
            var isuService = new IsuService();

            // var group = isuService.AddGroup("M3203");
            // Console.WriteLine("all good");
            //
            // isuService.AddStudent(group, "fun");
            // isuService.AddStudent(group, "sun");
            // Console.WriteLine("Sonya and Masha are besties forever!!!");
            //
            // Console.WriteLine(isuService.GetStudent(100001).Name);
            //
            // List<Student> students = new List<Student>();
            // students = isuService.FindStudents("M3203");
            //
            // foreach (var student in students)
            // {
            //     Console.WriteLine(student.Name);
            // }
            //
            // List<Student> courseStudents = new List<Student>();
            // CourseNumber course = new CourseNumber(2);
            // courseStudents = isuService.FindStudents(course);
            //
            // foreach (Student student in courseStudents)
            //  {
            //      Console.WriteLine(student.Name);
            //  }

            // Console.WriteLine(isuService.FindStudents("M3203"));
            var group1 = isuService.AddGroup("M3203");
            var student = isuService.AddStudent(group1, "ivan");
            var group2 = isuService.AddGroup("M3202");
            isuService.ChangeStudentGroup(student, group2);
            Console.WriteLine("it is student group1");
            foreach (var stud in group1.Students)
            {
                Console.WriteLine(stud.Name);
            }

            Console.WriteLine("it is student group2");
            foreach (var stud in group2.Students)
            {
                Console.WriteLine(stud.Name);
            }
        }
    }
}
