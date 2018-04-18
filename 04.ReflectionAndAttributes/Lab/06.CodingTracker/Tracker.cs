using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(c => c.AttributeType == typeof(SoftUniAttribute)))
            {
                var attributes = method.GetCustomAttributes(false);
                foreach (SoftUniAttribute attribute in attributes)
                {
                    System.Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}
