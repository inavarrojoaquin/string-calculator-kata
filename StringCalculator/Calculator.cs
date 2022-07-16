using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private int result;

        public Calculator()
        {
            result = 0;
        }

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return result;

            List<char> separators = new List<char> { ',', '\n' };

            if (input.StartsWith("//"))
                input = SpliSeparatorsAndNumbers(input, separators);
            
            foreach (string number in input.Split(separators.ToArray()))
                result += int.Parse(number);

            return result;
        }

        private string SpliSeparatorsAndNumbers(string input, List<char> separators)
        {
            separators.Clear();
            input = input.Remove(0, 2);
            foreach (char value in input)
            {
                int temp;
                if (!int.TryParse(value.ToString(), out temp))
                {
                    separators.Add(value);
                    input = input.Remove(0, 1);
                    continue;
                }
                break;
            }

            return input;
        }
    }
}