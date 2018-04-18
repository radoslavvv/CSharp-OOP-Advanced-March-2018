using P03_DependencyInversion;
using P03_DependencyInversion.Strategies;
using System;

namespace _03.DependencyInversion
{
    public class Program
    {
        public static void Main()
        {
            PrimitiveCalculator calc = new PrimitiveCalculator(new AdditionStrategy());

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();
                string firstItem = data[0];

                if (firstItem == "mode")
                {
                    char operand = data[1][0];

                    ICalculationStrategy calculationStrategy = null;
                    switch (operand)
                    {
                        case '+':
                            calculationStrategy = new AdditionStrategy();
                            break;
                        case '-':
                            calculationStrategy = new SubtractionStrategy();
                            break;
                        case '*':
                            calculationStrategy = new MutiplicationStrategy();
                            break;
                        case '/':
                            calculationStrategy = new DivisionStrategy();
                            break;
                    }

                    if (calculationStrategy == null)
                    {
                        throw new ArgumentException("Invalid mode entered!");
                    }

                    calc.ChangeStrategy(calculationStrategy);
                }
                else
                {
                    int firstOperand = int.Parse(firstItem);
                    int secondOperand = int.Parse(data[1]);

                    int result = calc.PerformCalculation(firstOperand, secondOperand);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
