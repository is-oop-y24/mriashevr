using Isu.Entities;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group group =_isuService.AddGroup("M3208");
            Student student = _isuService.AddStudent(group, "b");
            Assert.AreEqual(group, student.Group);
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group group = _isuService.AddGroup("M3211");
            Assert.Catch<IsuException>(() =>
            {
                for (int i = 0; i <= 31; i++)
                { 
                    Student student = _isuService.AddStudent(group, "Anthony");
                }
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
                Assert.Catch<IsuException>(() =>
                {
                    _isuService.AddGroup("Test");
                });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group group1 = _isuService.AddGroup("M3211");
            Group group2 = _isuService.AddGroup("M3212"); 
            Student student = _isuService.AddStudent(group1, "Ivan");
            _isuService.ChangeStudentGroup(student, group2); 
            Assert.AreEqual(group2, student.Group);
                
        }
    }
} 