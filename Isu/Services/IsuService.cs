using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            if (groupname[0] != 'M')
                throw new IsuException("Invalid group name");
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

            int counting = 0;

            foreach (Student stud in _students)
            {
                if (stud.Group == group)
                {
                    counting++;
                }
            }

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

            throw new IsuException("blya");
        }

        public Student FindStudent(string name)
        {
                var student = _students.Find(st => st.Name == name);
                if (student != null)
                {
                    return student;
                }

                return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            var allStudents = new List<Student>();
            foreach (Student stud in _students)
            {
                if (stud.Group.Name.GName == groupName)
                {
                   allStudents.Add(stud);
                }
            }

            return allStudents;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var allStudents = new List<Student>();
            foreach (Student stud in _students)
            {
                if (stud.Group.Name.СourseNumber == courseNumber)
                {
                        allStudents.Add(stud);
                }
            }

            return allStudents;
        }

        public Group FindGroup(string groupName)
        {
            foreach (var group in _groups)
            {
                if (group.Name.GName == groupName)
                {
                    return group;
                }
            }

            return null;
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            var allGroups = new List<Group>();
            foreach (var group in _groups)
            {
                if (group.Name.СourseNumber == courseNumber)
                {
                    allGroups.Add(group);
                }
            }

            return allGroups;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            student.Group = newGroup;
        }
    }
}