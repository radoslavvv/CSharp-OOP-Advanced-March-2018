using System;
using System.Collections.Generic;
using System.Text;

public interface IBoss
{
    IReadOnlyCollection<ISubordinate> Subordinates { get; }

    void AddSubordinate(ISubordinate subordinate);

    void OnSubordinateDeath(object sender);
}

