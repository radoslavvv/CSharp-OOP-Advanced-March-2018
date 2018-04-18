namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string fieldType = Console.ReadLine();


            while (fieldType != "HARVEST")
            {
                IEnumerable<FieldInfo> fields = typeof(HarvestingFields).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

                switch (fieldType)
                {
                    case "private":
                        fields = fields.Where(f => f.IsPrivate);
                        break;
                    case "protected":
                        fields = fields.Where(f => f.IsFamily);
                        break;
                    case "public":
                        fields = fields.Where(f => f.IsPublic);
                        break;
                }

                foreach (var field in fields)
                {
                    string acessModifier = field.Attributes.ToString().ToLower();
                    if (acessModifier == "family")
                    {
                        acessModifier = "protected";
                    }

                    Console.WriteLine($"{acessModifier} {field.FieldType.Name} {field.Name}");
                }

                fieldType = Console.ReadLine();
            }
        }
    }
}
