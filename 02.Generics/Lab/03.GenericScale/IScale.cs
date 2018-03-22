using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IScale<T>
{
    T Left { get; }

    T Right { get; }

    T GetHeavier();
}

