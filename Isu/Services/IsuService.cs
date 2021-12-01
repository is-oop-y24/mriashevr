using System.Collections.Generic;
using System.Linq;
using Isu.Entities;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private List<Group> _groups = new List<Group>();
        private List<Student> _students = new List<Student>();
        private int _maxAmoundOfStudents = 30;

        public Group AddGroup(string groupname)
        {
            var group = new Group(groupname);
            _groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new IsuException("invalid name student");
            }

            int counting = _students.Count(stud => stud.Group == @group);

            if (counting > _maxAmoundOfStudents)
            {
                throw new IsuException("Too many students");
            }

            var student = new Student(group, name);
            _students.Add(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            var student = _students.Find(st => st.Id == id);
            if (student != null)
            {
                return student;
            }

            throw new IsuException("no student found");
        }

        public Student FindStudent(string name)
        {
            return _students.Find(st => st.Name == name);
        }

        public List<Student> FindStudents(string groupName)
        {
            return _students.Where(st => st.Group.Name.Name == groupName).ToList();
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            return _students.Where(st => st.Group.Name.СourseNumber == courseNumber).ToList();
        }

        public Group FindGroup(string groupName)
        {
            return _groups.FirstOrDefault(@group => @group.Name.Name == groupName);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groups.Where(gr => gr.Name.СourseNumber == courseNumber).ToList();
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (student == null || newGroup == null)
            {
                throw new IsuException("invalid name of student or group");
            }

            student.Group = newGroup;
        }
    }
}