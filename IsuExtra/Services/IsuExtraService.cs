using System.Collections.Generic;
using System.Linq;
using Isu.Entities;
using Isu.Services;
using IsuExtra.Entities;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuExtraService
    {
        private Dictionary<Group, List<Lesson>> _dict = new Dictionary<Group, List<Lesson>>();
        public IsuExtraService()
        {
            IsuService = new IsuService();
        }

        public IsuService IsuService { get; }

        public void AddRegularLesson(Student student, string subject, double time, int day, int classroom, string teacher)
        {
            if (!_dict.ContainsKey(student.Group))
            {
                _dict.Add(student.Group, new List<Lesson>());
            }
            _dict.
            // List<Lesson> lesson = _dict[student.Group];
            // var les = new Lesson(subject, time, day, classroom, teacher);
            // lesson.Add(les);

            // foreach (Lesson lesson1 in lesson) _dict[student.Group].Add(lesson1);
        }

        public Student AddStudentOgnp(Student student, Ognp ognp, int ognpgroupnumber)
        {
            foreach (Lesson regularles in _dict.GetValueOrDefault(student.Group))
            {
                if (ognp.Stream.Lessons.Any(ognples => (regularles.Time == ognples.Time) && (regularles.WeekDay == ognples.WeekDay)))
                {
                    throw new IsuExtraException("Timetable is full");
                }
            }

            if (!ognp.CheckSpecialty(student, ognp))
            {
                throw new IsuExtraException("chosen course cant be taken");
            }

            ognp.Stream.AddStudentOgnpGroup(student, ognpgroupnumber);

            ognp.Stream.Students.Add(student);
            student.OgnpRegister = 1;
            foreach (Lesson les in ognp.Stream.Lessons)
            {
                _dict[student.Group].Add(les);
            }

            return student;
        }

        public Ognp AddNewOgnp(string ognpname, double time, int weekday, string nameteacher, int classroom)
        {
            var newstream = new Stream(ognpname, 01);
            var newlesson = new Lesson(ognpname, time, weekday, classroom, nameteacher);
            newstream.Lessons.Add(newlesson);
            var newognp = new Ognp(ognpname, newstream);
            return newognp;
        }

        public Student UnsubscribeOgnp(Student student, Ognp ognp)
        {
            student.OgnpRegister = 0;
            ognp.Stream.Students.Remove(student);
            foreach (Lesson les in ognp.Stream.Lessons)
            {
                _dict[student.Group].Remove(les);
            }

            return student;
        }

        public List<Student> NotSubscribedStudents()
        {
            return IsuService.Students.Where(student => student.OgnpRegister == 0).ToList();
        }
    }
}