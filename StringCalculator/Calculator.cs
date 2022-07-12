using System;
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

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return result;

            char[] separators = { ',', '\n' };
            foreach (string number in numbers.Split(separators)) 
                result += int.Parse(number);
            
            return result;
        }
    }
}