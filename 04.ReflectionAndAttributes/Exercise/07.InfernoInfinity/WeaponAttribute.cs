using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class WeaponAttribute : Attribute
{
    public WeaponAttribute(string author, int revision, string description, params string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = new List<string>(reviewers);
    }
    public string Author { get; set; }

    public int Revision { get; set; }

    public string Description { get; set; }

    public List<string> Reviewers { get; set; }

    public string Print(string field)
    {
        //var searchedField = typeof(WeaponAttribute).GetProperties().FirstOrDefault(p => p.Name == field);
        //var fieldValue = searchedField.GetValue(this);

        //if (field == "Reviewers")
        //{
        //    fieldValue = string.Join(", ", (string[])fieldValue);
        //}
        //return $"{field}: {fieldValue}";

        var joined = (string.Join(", ", this.Reviewers)).ToString();
        var outputResult = (field == "Reviewers") ? ($"Reviewers: {joined}") : string.Empty;
        outputResult = field == "Description" ? $"Class description: {this.Description}" : outputResult;

        if (outputResult == string.Empty)
        {
            var fieldToTake = typeof(WeaponAttribute).GetProperties().FirstOrDefault(p => p.Name == field);
            var fieldValue = fieldToTake.GetValue(this).ToString();
            outputResult = $"{field}: {fieldValue}";
        }

        return outputResult;
    }
}

