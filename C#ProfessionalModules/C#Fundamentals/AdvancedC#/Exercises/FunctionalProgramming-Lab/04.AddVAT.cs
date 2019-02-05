using System;
using System.Linq;

namespace _04.Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(d => double.Parse(d))
                .Select(d => d * 1.2)
                .ToList()
                .ForEach(d => Console.WriteLine($"{d:f2}"));
        }
    }
}
