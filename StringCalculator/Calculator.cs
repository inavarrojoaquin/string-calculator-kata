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

            foreach(string number in numbers.Split(',')) 
                result += int.Parse(number);
            
            return result;
        }
    }
}