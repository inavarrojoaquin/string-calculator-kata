using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        private int result;
        private List<int> negatives;

        public Calculator()
        {
            result = 0;
            negatives = new List<int>();
        }

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return result;

            List<char> separators = new List<char> { ',', '\n' };

            if (input.StartsWith("//"))
                input = SpliSeparatorsAndNumbers(input, separators);
            
            foreach (string stringNumber in input.Split(separators.ToArray())) 
            {
                int number = int.Parse(stringNumber);
                
                if ( number < 0)
                    negatives.Add(number);
                
                result += number;
            }

            if (negatives.Any())
                throw new Exception("error: negatives not allowed: " + string.Join(' ', negatives));

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