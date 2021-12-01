using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Isu.Entities;
using Isu.Services;
using IsuExtra.Entities;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuExtraService
    {
    private Dictionary<Group, List<Lesson>> _timetableDict = new Dictionary<Group, List<Lesson>>();

    public IsuExtraService()
    {
        IsuService = new IsuService();
    }

    public IsuService IsuService { get; }

    public void AddRegularLesson(Student student, string subject, DateTime time, int classroom, string teacher)
    {
        var lesson = new Lesson(subject, time, classroom, teacher);
        if (!_timetableDict.ContainsKey(student.Group))
        {
            _timetableDict.Add(student.Group, new List<Lesson>());
        }

        _timetableDict[student.Group].Add(lesson);
    }

    public Student AddStudentOgnp(Student student, Ognp ognp)
    {
        List<Lesson> timetable = _timetableDict[student.Group];
        foreach (Lesson regularles in timetable)
        {
            if (ognp.Stream.Lessons.Any(ognples => (regularles.Time == ognples.Time)))
            {
                throw new IsuExtraException("Timetable is full");
            }
        }

        if (!ognp.CheckSpecialty(student, ognp))
        {
            throw new IsuExtraException("chosen course cant be taken");
        }

        ognp.Stream.AddToGroup(student, ognp);
        ognp.Stream.AddStudentOgnpGroup(student, ognp);

        ognp.Stream.Students.Add(student);
        if (student.OgnpRegister != 0)
        {
            throw new Exception("Man, you already have ognp");
        }

        student.OgnpRegister = 1;
        foreach (Lesson les in ognp.Stream.Lessons)
        {
            _timetableDict[student.Group].Add(les);
        }

        return student;
    }

    public Ognp AddNewOgnp(string ognpname, DateTime time, string nameteacher, int classroom)
    {
        var newstream = new Stream(ognpname, 1);
        var newlesson = new Lesson(ognpname, time, classroom, nameteacher);
        newstream.Lessons.Add(newlesson);
        var newognp = new Ognp(ognpname, newstream);
        return newognp;
    }

    public Student UnsubscribeOgnp(Student student, Ognp ognp)
    {
        student.OgnpRegister = 0;
        ognp.Stream.Students.Remove(student);
        foreach (Lesson les in ognp.Stream.Lessons)
        {
            _timetableDict[student.Group].Remove(les);
        }

        return student;
    }

    public List<Student> NotSubscribedStudents()
    {
        return IsuService.Students.Where(student => student.OgnpRegister == 0).ToList();
    }
    }
}