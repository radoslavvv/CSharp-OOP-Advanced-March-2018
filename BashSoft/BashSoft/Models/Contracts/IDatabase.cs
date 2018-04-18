using System;
using System.Collections.Generic;
using System.Text;

public interface IDatabase : IOrderedTaker, IFilteredTaker, IRequester
{
    void UnloadData();

    void LoadData(string dataName);
}

