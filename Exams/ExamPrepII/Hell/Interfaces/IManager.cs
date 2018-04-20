using System.Collections.Generic;

public interface IManager
{
    string Quit(IList<string> argsList);

    string AddRecipe(IList<string> arguments);

    string AddItem(IList<string> arguments);
    string Inspect(IList<string> arguments);
    string AddHero(IList<string> arguments);
}