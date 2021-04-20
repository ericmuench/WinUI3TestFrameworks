using System;

namespace ClassLibrary
{
    public class Calculator
    {
        public string Name { get; set; } = "NO_NAME";

        public double add(double n1, double n2)
        {
            return n1 + n2;
        }

        public double subtract(double n1, double n2)
        {
            return n1 - n2;
        }


        public double multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public double divide(double n1, double n2)
        {
            if (n2 == 0) 
            {
                throw new Exception("Division by Zero is impossible");
            }
            return n1 / n2;   
        }
    }
}
