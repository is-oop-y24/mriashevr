using System;
using System.Numerics;
using System.Text.RegularExpressions;
using Isu.Entities;
using Isu.Services;
using Isu.Tools;
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
            Catch<IsuExtraException>(() =>
            {
                _isuExtraService.AddNewOgnp("L2", 11.20, 2, "kolesnikov", 101);
            });
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {    
        }
    }
}