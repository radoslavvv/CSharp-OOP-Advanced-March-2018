using System;
using System.Collections.Generic;
using System.Text;

public interface IDataSorter
{
    void OrderAndTake(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake);
}

