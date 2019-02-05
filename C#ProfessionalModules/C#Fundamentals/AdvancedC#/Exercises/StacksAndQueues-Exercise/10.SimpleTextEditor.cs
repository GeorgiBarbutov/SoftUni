using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUni_CSharp_Fundamentals_Exercises
{
    class SimpleTextEditor
    {
        static void Tenth(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> textHistory = new Stack<string>();
            textHistory.Push("");

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(' ');

                string commandId = commands[0];

                if (commandId == "1")
                {
                    text.Append(commands[1]);

                    textHistory.Push(text.ToString());
                }
                else if (commandId == "2")
                {
                    int removeIndex = text.Length - int.Parse(commands[1]);

                    if (removeIndex < 0)
                    {
                        removeIndex = 0;
                    }

                    text.Remove(removeIndex, int.Parse(commands[1]));

                    textHistory.Push(text.ToString());
                }
                else if (commandId == "3")
                {
                        Console.WriteLine(text[int.Parse(commands[1]) - 1]);
                }
                else if (commandId == "4")
                {
                    if (textHistory.Count > 0)
                    {
                        textHistory.Pop();
                        text.Clear();
                        text.Append(textHistory.Peek());
                    }
                }
            }
        }
    }
}
