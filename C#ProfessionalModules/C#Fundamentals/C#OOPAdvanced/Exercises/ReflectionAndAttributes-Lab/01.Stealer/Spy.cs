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
}

