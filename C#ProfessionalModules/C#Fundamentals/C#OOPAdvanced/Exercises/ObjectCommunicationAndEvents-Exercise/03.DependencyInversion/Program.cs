using P03_DependencyInversion.Contracts;
using P03_DependencyInversion.Strategies;
using System;

namespace P03_DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            IStrategy strategy = new AdditionStrategy();
            IPrimitiveCalculator primitiveCalculator = new PrimitiveCalculator(strategy);

            string[] commandArgs;

            while ((commandArgs = Console.ReadLine().Split(' '))[0] != "End")
            {
                if (commandArgs[0] == "mode")
                {
                    ChangeStrategy(primitiveCalculator, commandArgs);
                }
                else
                {
                    PrintResult(primitiveCalculator, commandArgs);
                }
            }
        }

        private static void PrintResult(IPrimitiveCalculator primitiveCalculator, string[] commandArgs)
        {
            int result = primitiveCalculator.PerformCalculation(int.Parse(commandArgs[0]), int.Parse(commandArgs[1]));

            Console.WriteLine(result);
        }

        private static void ChangeStrategy(IPrimitiveCalculator primitiveCalculator, string[] commandArgs)
        {
            char @operator = char.Parse(commandArgs[1]);

            if (@operator == '+')
            {
                primitiveCalculator.ChangeStrategy(new AdditionStrategy());
            }
            else if (@operator == '-')
            {
                primitiveCalculator.ChangeStrategy(new SubtractionStrategy());
            }
            else if (@operator == '*')
            {
                primitiveCalculator.ChangeStrategy(new MultiplicationStrategy());
            }
            else if (@operator == '/')
            {
                primitiveCalculator.ChangeStrategy(new DivisionStrategy());
            }
        }
    }
}
