using BashSoft.Models;
using System;
using System.Collections.Generic;

public interface IStudent : IComparable<IStudent>
{
    string UserName { get; }

    IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }

    IReadOnlyDictionary<string, double> MarksByCourseName { get; }

    void SetMarkOnCourse(string courseName, params int[] scores);

    void EnrollInCourse(ICourse course);
}