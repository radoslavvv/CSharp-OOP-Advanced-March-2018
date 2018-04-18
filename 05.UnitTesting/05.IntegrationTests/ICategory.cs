using System.Collections.Generic;

public interface ICategory
{
    IList<ICategory> ChildCategories { get; }
    string Name { get; }
    ICategory Parent { get; }
    IList<IUser> Users { get; }

    void AddChild(ICategory child);
    void AddUser(IUser user);
    void MoveUsersToParent();
    void RemoveChild(string name);
    void SetParent(ICategory category);
}