using System;
using System.Collections;
using System.Collections.Generic;
namespace Isu.Entities
{
    public class Student
    {
        public Student(Group group, string name)
        {
            Name = name;
            Id = IdGenerator.NewId();
            Group = group;
        }

        public Group Group { get; set; }
        public string Name { get; }
        public int Id { get; }
    }
}