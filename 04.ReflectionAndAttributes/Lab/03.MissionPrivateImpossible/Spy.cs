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

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder result = new StringBuilder();

        var type = Type.GetType(className);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var field in fields)
        {
            result.AppendLine($"{field.Name} must be private!");
        }

        foreach (var property in properties)
        {
            if (property.GetMethod?.IsPrivate == true)
            {
                result.AppendLine($"{property.GetMethod.Name} have to be public!");
            }
        }

        foreach (var property in properties)
        {
            if (property.SetMethod?.IsPublic == true)
            {
                result.AppendLine($"{property.SetMethod.Name} have to be private!");
            }
        }

        return result.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder result = new StringBuilder();
        var type = Type.GetType(className);

        result.AppendLine($"All Private Methods of Class: {className}");
        result.AppendLine($"Base Class: {type.BaseType.Name}");

        var methods = type.GetMethods(BindingFlags.Instance  | BindingFlags.NonPublic);

        foreach (var method in methods)
        {
            result.AppendLine($"{method.Name}");
        }

        return result.ToString().Trim();
    }
}


