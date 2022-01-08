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
            OgnpRegister = 0;
        }

        public Group Group { get; set; }
        public string Name { get; }
        public int Id { get; }
        public int OgnpRegister { get; set; }
    }
}