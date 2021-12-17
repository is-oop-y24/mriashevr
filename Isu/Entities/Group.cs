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
        }

        public GroupName Name { get; }
    }
}