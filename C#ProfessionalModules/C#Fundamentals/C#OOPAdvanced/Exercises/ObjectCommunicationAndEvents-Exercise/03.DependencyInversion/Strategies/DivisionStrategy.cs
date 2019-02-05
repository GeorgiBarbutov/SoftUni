using P03_DependencyInversion.Contracts;

namespace P03_DependencyInversion.Strategies
{
    class DivisionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
