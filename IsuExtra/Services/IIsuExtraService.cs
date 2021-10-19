using System.Collections.Generic;
using Isu.Entities;
using IsuExtra.Entities;

namespace IsuExtra.Services
{
    public interface IIsuExtraService
    {
        Student AddStudentOgnp(Student student, Ognp ognp, int ognpgroupnumber);
        Ognp AddNewOgnp(string ognpname, double time, int weekday, string nameteacher, int classroom);
        Student UnsubscribeOgnp(Student student, Ognp ognp);
        List<Student> NotSubscribedStudents();
    }
}