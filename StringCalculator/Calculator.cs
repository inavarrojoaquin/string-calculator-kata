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

            List<string> separators = new List<string> { ",", "\n" };

            if (input.StartsWith("//"))
                input = SpliSeparatorsAndNumbers(input, separators);

            foreach (string stringNumber in input.Split(separators.ToArray(),
                                                        StringSplitOptions.RemoveEmptyEntries)) 
            {
                int number = int.Parse(stringNumber);
                
                if (number < 0)
                    negatives.Add(number);

                if (number > 100)
                    continue;
                
                result += number;
            }

            if (negatives.Any())
                throw new Exception("error: negatives not allowed: " + string.Join(' ', negatives));

            return result;
        }

        private string SpliSeparatorsAndNumbers(string input, List<string> separators)
        {
            separators.Clear();
            input = input.Remove(0, 2);
            string arbitrary = null;
            foreach (char value in input)
            {
                int temp;
                if (!int.TryParse(value.ToString(), out temp))
                {
                    string stringValue = value.ToString();
                    if (stringValue == "[")
                        arbitrary = string.Empty;
                    
                    if (stringValue == "]")
                    {
                        stringValue = arbitrary.Replace("[", "");
                        arbitrary = null;
                    }

                    if (arbitrary != null)
                        arbitrary += value;
                    else
                        separators.Add(stringValue);

                    input = input.Remove(0, 1);
                    continue;
                }
                break;
            }

            return input;
        }
    }
}