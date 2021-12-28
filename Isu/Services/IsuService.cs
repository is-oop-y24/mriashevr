using System.Collections.Generic;
using System.Linq;
using Isu.Entities;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private int _maxAmoundOfStudents = 30;
        public IsuService()
        {
            Students = new List<Student>();
            Groups = new List<Group>();
        }

        public List<Student> Students { get; }
        public List<Group> Groups { get; }

        public Group AddGroup(string groupname)
        {
            var group = new Group(groupname);
            Groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new IsuException("invalid name student");
            }

            int counting = Students.Count(stud => stud.Group == @group);

            if (counting > _maxAmoundOfStudents)
            {
                throw new IsuException("Too many students");
            }

            var student = new Student(group, name);
            Students.Add(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            var student = Students.Find(st => st.Id == id);
            if (student != null)
            {
                return student;
            }

            throw new IsuException("no student found");
        }

        public Student FindStudent(string name)
        {
            return Students.Find(st => st.Name == name);
        }

        public List<Student> FindStudents(string groupName)
        {
            return Students.Where(st => st.Group.Name.Name == groupName).ToList();
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            return Students.Where(st => st.Group.Name.СourseNumber == courseNumber).ToList();
        }

        public Group FindGroup(string groupName)
        {
            return Groups.FirstOrDefault(@group => @group.Name.Name == groupName);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return Groups.Where(gr => gr.Name.СourseNumber == courseNumber).ToList();
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