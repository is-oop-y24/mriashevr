using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Isu.Entities;
using IsuExtra.Tools;

namespace IsuExtra.Entities
{
    public class Stream
    {
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

        public List<Student> ReturnStudents(Ognp ognp)
        {
            var tracklist = ognp.Stream.Students.ToList();
            return tracklist;
        }

        public Student AddStudentOgnpGroup(Student student, int number)
        {
            int contained = 0;
            foreach (Student st in _streamgroup[number])
            {
                contained++;
            }

            if (contained > 30)
            {
                throw new IsuExtraException();
            }

            _streamgroup[number].Add(student);
            return student;
        }

        public List<Student> StudentsInNamedGroup(int number)
        {
            return _streamgroup[number];
        }
    }
}