using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = Type.GetType("Program");

        MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

        foreach (var method in methods)
        {
            var attributes = method.CustomAttributes.Where(x => x.AttributeType == typeof(SoftUniAttribute));

            foreach (var attribute in attributes)
            {
                Console.WriteLine($"{method.Name} is writen by {attribute.ConstructorArguments[0]}");
            }
        }
    }
}

