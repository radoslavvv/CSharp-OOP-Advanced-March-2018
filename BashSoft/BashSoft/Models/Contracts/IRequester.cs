﻿using System;
using System.Collections.Generic;
using System.Text;

public interface IRequester
{
    void GetAllStudentsFromCourse(string courseName);

    void GetStudentScoresFromCourse(string courseName, string username);

    ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

    ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
}

