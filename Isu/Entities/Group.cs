using System;
using System.Collections;
using System.Collections.Generic;

namespace Isu.Entities
{
    public class Group
    {
        public Group(string name)
        {
            Name = new GroupName(name);
            Students = new List<Student>();
        }

        public List<Student> Students { get; } = new List<Student>();
        public GroupName Name { get; }

        public Student GetStudent(int id)
        {
            return Students.Find(st => st.Id == id);
        }

        public Student FindStudent(string name)
        {
            return Students.Find(st => st.Name == name);
        }

        // public void AddGroup(string name)
       // {
       //     throw new System.NotImplementedException();
       // }
    }
}