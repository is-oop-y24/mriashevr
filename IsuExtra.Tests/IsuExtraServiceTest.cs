using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using Isu.Entities;
using Isu.Services;
using Isu.Tools;
using IsuExtra.Entities;
using IsuExtra.Services;
using IsuExtra.Tools;
using NUnit.Framework;
using static NUnit.Framework.Assert;
using Group = Isu.Entities.Group;

namespace IsuExtra.Tests
{
    public class Tests
    {
        private IsuExtraService _isuExtraService;
        private IsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
            _isuExtraService = new IsuExtraService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group group = _isuService.AddGroup("M3208");
            Student student = _isuService.AddStudent(group, "ivan");
            _isuExtraService.AddRegularLesson(student, "math", 11.20, 2, 123, "kk");
            Ognp ognp = _isuExtraService.AddNewOgnp("L2", 11.20, 2, "kolesnikov", 101);
            Catch<IsuExtraException>(() =>
            {
                _isuExtraService.AddStudentOgnp(student, ognp);
            });
        }

        [Test]
        public void ListOfNotSubscribedStudents()
        {
            Group group = _isuService.AddGroup("M3208");
            Student student1 = _isuService.AddStudent(group, "ivan");
            Student student2 = _isuService.AddStudent(group, "ian");
            _isuExtraService.AddRegularLesson(student1, "math", 12.20, 3, 123, "kk");
            _isuExtraService.AddRegularLesson(student2, "math", 11.20, 4, 123, "kk");
            Ognp ognp = _isuExtraService.AddNewOgnp("L2", 11.20, 2, "kolesnikov", 101);
            _isuExtraService.AddStudentOgnp(student1, ognp);
            // var list = _isuExtraService.NotSubscribedStudents();
            var list = _isuService.Students.Where(student => student.OgnpRegister == 0).ToList();
            List<Student> result = new List<Student>() {student2};
            Assert.AreEqual(result, list);
        }

        [Test]
        public void AddStudentToUnavaluableOgnp()
        {
            Group group = _isuService.AddGroup("M3208");
            Student student = _isuService.AddStudent(group, "ivalena");
            _isuExtraService.AddRegularLesson(student, "math", 11.20, 2, 123, "kk");
            Ognp ognp = _isuExtraService.AddNewOgnp("M3", 11.20, 5, "kolesnikov", 101);
            Catch<IsuExtraException>(() =>
            {
                _isuExtraService.AddStudentOgnp(student, ognp);
            });
        }
    }
}