namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");
            BlackBoxInteger blackBoxInteger = (BlackBoxInteger)Activator.CreateInstance(type, true);

            string[] commandParams;

            while((commandParams = Console.ReadLine().Split('_'))[0] != "END")
            {
                string command = commandParams[0];
                int number = int.Parse(commandParams[1]);

                ExecuteCommand(type, blackBoxInteger, command, number);
            }
        }

        private static void ExecuteCommand(Type type, BlackBoxInteger blackBoxInteger, string command, int number)
        {
            if (command == "Add")
            {
                InvokeMethod(type, blackBoxInteger, number, "Add");
            }
            else if (command == "Subtract")
            {
                InvokeMethod(type, blackBoxInteger, number, "Subtract");
            }
            else if (command == "Multiply")
            {
                InvokeMethod(type, blackBoxInteger, number, "Multiply");
            }
            else if (command == "Divide")
            {
                InvokeMethod(type, blackBoxInteger, number, "Divide");
            }
            else if (command == "LeftShift")
            {
                InvokeMethod(type, blackBoxInteger, number, "LeftShift");
            }
            else if (command == "RightShift")
            {
                InvokeMethod(type, blackBoxInteger, number, "RightShift");
            }
        }

        private static void InvokeMethod(Type type, BlackBoxInteger blackBoxInteger, int number, string methodName)
        {
            MethodInfo method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(blackBoxInteger, new object[] { number });
            FieldInfo field = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine(field.GetValue(blackBoxInteger));
        }
    }
}
