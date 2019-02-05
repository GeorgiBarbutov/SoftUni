using System;
using System.Linq;

namespace _03.Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[]{ ' '},StringSplitOptions.RemoveEmptyEntries);

            if(words.Length != 0)
            {
                Func<string, bool> startsWithUpperCase = s => char.IsUpper(s[0]);

                Console.WriteLine(String.Join("\r\n", words.Where(startsWithUpperCase)));
            }
        }
    }
}
