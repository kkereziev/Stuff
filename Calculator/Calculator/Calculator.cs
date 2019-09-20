using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    class Calculator
    {
        static void Main()
        {
            string expression = "3/3*2";
            double result = Evaluate(expression);
            Console.WriteLine(result);
        }

        static double Evaluate(string expression)
        {
            string allowedOpperators = "+-/*";
            Stack<double> numbers = new Stack<double>();
            Stack<char> operators = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                var currChar = expression[i];
                if (currChar == '(')
                {
                    operators.Push(currChar);
                }
                else if (currChar == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        char op = operators.Pop();
                        double operandTwo = numbers.Pop();
                        double operandOne = numbers.Pop();
                        double newValue = ApplyOperation(op, operandOne, operandTwo);
                        numbers.Push(newValue);
                    }
                    operators.Pop(); // (
                }
                else if (allowedOpperators.Contains(currChar))
                {
                    while (operators.Count > 0 && Priority(operators.Peek()) > Priority(currChar))
                    {
                        char op = operators.Pop();
                        double operandTwo = numbers.Pop();
                        double operandOne = numbers.Pop();
                        double newValue = ApplyOperation(op, operandOne, operandTwo);
                        numbers.Push(newValue);
                    }
                    operators.Push(currChar);
                }
                else if (char.IsDigit(currChar) || currChar == '.')
                {
                    StringBuilder number = new StringBuilder();
                    while (char.IsDigit(currChar) || currChar == '.')
                    {
                        number.Append(currChar);
                        i++;
                        if (i == expression.Length)
                        {
                            break;
                        }
                        currChar = expression[i];
                    }
                    i--;
                    numbers.Push(double.Parse(number.ToString()));
                }
            }

            while (operators.Count > 0)
            {
                char op = operators.Pop();
                double operandTwo = numbers.Pop();
                double operandOne = numbers.Pop();
                double newValue = ApplyOperation(op, operandOne, operandTwo);
                numbers.Push(newValue);
            }
            return numbers.Pop();
        }

        static double ApplyOperation(char operation, double operandOne, double operandTwo)
        {
            switch (operation)
            {
                case '+': return operandOne + operandTwo;
                case '-': return operandOne - operandTwo;
                case '*': return operandOne * operandTwo;
                case '/':
                    if (operandTwo == 0) throw new Exception("Division by zero!");
                    else
                    {
                        return operandOne / operandTwo;
                    }
                default: return 0.0;
            }
        }

        static int Priority(char operation)
        {
            switch (operation)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: return 0;
            }
        }
    }
}
