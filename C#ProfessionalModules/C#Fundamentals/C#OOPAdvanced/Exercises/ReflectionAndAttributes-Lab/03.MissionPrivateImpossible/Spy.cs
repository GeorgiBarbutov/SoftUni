using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] nameOfFields)
    {
        Type type = Type.GetType(nameOfClass);
        FieldInfo[] fieldInfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Static | BindingFlags.Instance);

        object classInstance = Activator.CreateInstance(type);

        StringBuilder stringBuilder = new StringBuilder($"Class under investigation: {nameOfClass}");

        foreach (var field in fieldInfo.Where(x => nameOfFields.Contains(x.Name)))
        {
            stringBuilder.Append(Environment.NewLine + $"{field.Name} = {field.GetValue(classInstance)}");
        }        

        return stringBuilder.ToString();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type type = Type.GetType(className);
        FieldInfo[] fieldsInfo = type.GetFields();
        MethodInfo[] methodsInfo = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Instance | BindingFlags.Static);

        StringBuilder stringBuilder = new StringBuilder();

        foreach (var field in fieldsInfo)
        {
            stringBuilder.AppendLine($"{field.Name} must be private!");
        }
        foreach (var method in methodsInfo.Where(x => x.Name.Substring(0, 3) == "get" && !x.IsPublic))
        {
            stringBuilder.AppendLine($"{method.Name} have to be public!");
        }
        foreach (var method in methodsInfo.Where(x => x.Name.Substring(0, 3) == "set" && x.IsPublic))
        {
            stringBuilder.AppendLine($"{method.Name} have to be private!");
        }

        return stringBuilder.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type type = Type.GetType(className);
        MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder stringBuilder = new StringBuilder($"All Private Methods of Class: {className}" + Environment.NewLine +
            $"Base Class: {type.BaseType.Name}");

        foreach (var method in methods)
        {
            stringBuilder.Append(Environment.NewLine + method.Name);
        }

        return stringBuilder.ToString();
    }
}

