 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = Type.GetType("P01_HarvestingFields.HarvestingFields");
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            HarvestingFields harvestingFields = new HarvestingFields();

            string command;

            while((command = Console.ReadLine()) != "HARVEST")
            {
                if(command == "public")
                {
                    foreach (var field in fields.Where(x => x.IsPublic))
                    {
                        Console.WriteLine("public " + field.FieldType.Name + " " + field.Name);
                    }
                }
                else if (command == "private")
                {
                    foreach (var field in fields.Where(x => x.IsPrivate))
                    {
                        Console.WriteLine("private " + field.FieldType.Name + " " + field.Name);
                    }
                }
                else if (command == "protected")
                {
                    foreach (var field in fields.Where(x => x.IsFamily))
                    {
                        Console.WriteLine("protected " + field.FieldType.Name + " " + field.Name);
                    }
                }
                else if (command == "all")
                {
                    foreach (var field in fields)
                    {
                        string atribute = field.Attributes.ToString().ToLower();

                        if(atribute == "family")
                        {
                            atribute = "protected";
                        }

                        Console.WriteLine(atribute + " " + field.FieldType.Name + " " + field.Name);
                    }
                }
            }

        }
    }
}
