using P03_DependencyInversion.Contracts;

namespace P03_DependencyInversion.Strategies
{
    class MultiplicationStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
