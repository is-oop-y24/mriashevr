using System.Security.Cryptography;
using Isu.Entities;

namespace IsuExtra.Entities
{
    public class Ognp
    {
        public Ognp(string name, Stream stream)
        {
            Name = name;
            OgnpSpecialty = name.Substring(0, 2);
            Stream = stream;
        }

        public string Name { get; }
        public Stream Stream { get; }
        public string OgnpSpecialty { get; }

        public bool CheckSpecialty(Student student, Ognp ognp)
        {
            return student.Group.Name.Specialty != ognp.OgnpSpecialty;
        }
    }
}