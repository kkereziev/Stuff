using System;
using System.Collections.Generic;
using System.Linq;

namespace JsTests
{
    class Program
    {
        public static char[,] tokens =
        {
            {'(',')' },
            {'{','}' },
            {'[',']' }
        };
        //{()[{({})[]()}]}([])
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Console.WriteLine(IsBalanced(expression));
        }

        private static bool Matches(char open, char closed)
        {
            for (int i = 0; i < tokens.GetLength(0); i++)
            {
                if (tokens[i, 0] == open)
                {
                    return tokens[i, 1] == closed;
                }
            }
            return false;
        }

        private static bool IsOpen(char item)
        {
            for (int i = 0; i < tokens.GetLength(0); i++)
            {
                if (tokens[i, 0] == item)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsBalanced(string expression)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var item in expression.ToCharArray())
            {
                if (IsOpen(item))
                {
                    stack.Push(item);
                }
                else
                {
                    if (stack.Count == 0 || !Matches(stack.Pop(), item))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }
}
