using System.Collections;
using System.Collections.Generic;

public interface IRecipe : IItem
{
    string Name { get; }

    IList<string> RequiredItems { get; }
}