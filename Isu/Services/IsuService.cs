using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Isu.Entities;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        /*public IsuService(int id)
        {
            Groups = new List<Group>();
        }*/

        private List<Group> Groups { get; } = new List<Group>();

        public Group AddGroup(string groupname)
        {
            if (groupname[0] != 'M')
                throw new IsuException("Invalid group name");
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

            if (group.Students.Count >= 30)
                throw new IsuException("Too many students");
            var student = new Student(name);
            group.Students.Add(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            foreach (var group in Groups)
            {
                var student = group.GetStudent(id);
                if (student != null)
                    return student;
            }

            throw new IsuException("blya");
        }

        public Student FindStudent(string name)
        {
            foreach (var group in Groups)
            {
                var student = group.FindStudent(name);
                if (student != null)
                    return student;
            }

            return null;
        }

        public List<Student> FindStudents(string groupName)
        {
            foreach (var group in Groups)
            {
                if (group.Name.GName == groupName)
                {
                    return group.Students;
                }
            }

            return null;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var allStudents = new List<Student>();
            foreach (var group in Groups)
            {
                if (group.Name.CourseNumber == courseNumber)
                {
                    foreach (Student student in group.Students)
                        allStudents.Add(student);
                }
            }

            return allStudents;
        }

        public Group FindGroup(string groupName)
        {
            foreach (var group in Groups)
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
            foreach (var group in Groups)
            {
                if (group.Name.CourseNumber.Course == courseNumber.Course)
                {
                    allGroups.Add(group);
                }
            }

            return allGroups;
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            foreach (var group in Groups)
            {
                foreach (var stud in group.Students.ToList())
                {
                    if (stud.Id == student.Id)
                    {
                        group.Students.Remove(student);
                        newGroup.Students.Add(student);
                    }
                }
            }
        }
    }
}