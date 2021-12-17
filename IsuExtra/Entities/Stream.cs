using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Isu.Entities;
using IsuExtra.Tools;

namespace IsuExtra.Entities
{
    public class Stream
    {
        private int maxStudents = 30;
        private Dictionary<int, List<Student>> _streamgroup;
        public Stream(string name, int groupnumber)
        {
            Speciality = name;
            Students = new List<Student>();
            Lessons = new List<Lesson>();
            _streamgroup = new Dictionary<int, List<Student>>();
            GroupNumber = groupnumber;
        }

        public string Speciality { get; }
        public List<Student> Students { get; }
        public List<Lesson> Lessons { get; }
        public int GroupNumber { get; }

        public static IEnumerable<Student> ReturnStudents(Ognp ognp)
        {
            return ognp.Stream.Students.ToList();
        }

        public Student AddStudentOgnpGroup(Student student, Ognp ognp)
        {
            int contained = _streamgroup[ognp.Stream.GroupNumber].Count;

            if (contained > maxStudents)
            {
                throw new IsuExtraException();
            }

            _streamgroup[ognp.Stream.GroupNumber].Add(student);
            return student;
        }

        public List<Student> StudentsInNamedGroup(int number)
        {
            return _streamgroup[number];
        }

        public void AddToGroup(Student student, Ognp ognp)
        {
            _streamgroup.Add(ognp.Stream.GroupNumber, new List<Student>());
            _streamgroup[ognp.Stream.GroupNumber].Add(student);
        }
    }
}