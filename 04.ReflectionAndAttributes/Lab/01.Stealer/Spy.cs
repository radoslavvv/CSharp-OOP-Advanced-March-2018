using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        StringBuilder result = new StringBuilder();

        var type = Type.GetType(className);
        var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        result.AppendLine($"Class under investigation: {className}");

        var classInstance = Activator.CreateInstance(type);

        foreach (var field in fields)
        {
            string fieldName = field.Name;
            if (fieldNames.Contains(fieldName))
            {
                result.AppendLine($"{fieldName} = {field.GetValue(classInstance)}");
            }
        }

        return result.ToString().Trim();
    }
}

