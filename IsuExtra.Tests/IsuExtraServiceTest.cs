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
            DateTime time = new DateTime(2021, 10, 23, 13, 30, 0);
            _isuExtraService.AddRegularLesson(student, "math", time, 123, "kk");
            Ognp ognp = _isuExtraService.AddNewOgnp("L2", time, "kolesnikov", 101);
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
            DateTime time1 = new DateTime(2021, 10, 23, 13, 30, 0);
            DateTime time2 = new DateTime(2021, 10, 22, 12, 0, 0);
            DateTime time3 = new DateTime(2021, 10, 25, 12, 0, 0);
            _isuExtraService.AddRegularLesson(student1, "math", time2, 123, "kk");
            _isuExtraService.AddRegularLesson(student2, "math", time1, 123, "kk");
            Ognp ognp = _isuExtraService.AddNewOgnp("L2", time3, "kolesnikov", 101);
            _isuExtraService.AddStudentOgnp(student1, ognp);
            var list = _isuService.Students.Where(student => student.OgnpRegister == 0).ToList();
            List<Student> result = new List<Student>() {student2};
            Assert.AreEqual(result, list);
        }

        [Test]
        public void AddStudentToUnavaluableOgnp()
        {
            Group group = _isuService.AddGroup("M3208");
            Student student = _isuService.AddStudent(group, "ivalena");
            DateTime time1 = new DateTime(2021, 10, 23, 13, 30, 0);
            DateTime time2 = new DateTime(2021, 10, 25, 13, 30, 0);
            _isuExtraService.AddRegularLesson(student, "math", time1, 123, "kk");
            Ognp ognp = _isuExtraService.AddNewOgnp("M3", time2, "kolesnikov", 101);
            Catch<IsuExtraException>(() =>
            {
                _isuExtraService.AddStudentOgnp(student, ognp);
            });
        }
    }
}