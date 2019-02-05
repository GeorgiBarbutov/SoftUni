﻿namespace P03_DependencyInversion.Contracts
{
    public interface IPrimitiveCalculator
    {
        void ChangeStrategy(IStrategy strategy);
        int PerformCalculation(int firstOperand, int secondOperand);
    }
}