using System;
using System.Collections.Generic;
using System.Text;

public class MutiplicationStrategy : ICalculationStrategy
{
    public int Calculate(int firstOperand, int secondOperand)
    {
        return firstOperand * secondOperand;
    }
}

