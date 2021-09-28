using System;
using System.Collections;
using System.Collections.Generic;
namespace Isu.Entities
{
    public class IdGenerator
    {
        private static int _id;
        public IdGenerator()
        {
            Id = (++_id) + 10000;
        }

        public int Id { get; }
    }
}