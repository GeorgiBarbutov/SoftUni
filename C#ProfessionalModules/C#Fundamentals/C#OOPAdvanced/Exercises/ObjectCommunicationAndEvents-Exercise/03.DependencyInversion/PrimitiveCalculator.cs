using P03_DependencyInversion.Contracts;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator : IPrimitiveCalculator
    {
        private bool isAddition;
        private IStrategy strategy;

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
            this.isAddition = true;
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            int result = this.strategy.Calculate(firstOperand, secondOperand);

            return result;
        }
    }
}
