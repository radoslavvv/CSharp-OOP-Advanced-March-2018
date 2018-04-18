using System.Collections.Generic;

public interface IUser
{
    IEnumerable<ICategory> Categories { get; }
    string Name { get; }

    void AddCategory(ICategory category);
    void RemoveCategory(ICategory category);
}