using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSection
{
    class Program
    {
        static float n1 = 432, n2 = 543;
        private static void Main(string[] args)
        {
            var addition = Add();
            var substraction = Substract();
            var multiplication = Multiply();
            var division = Divide();

            Console.WriteLine(addition);
            Console.WriteLine(substraction);
            Console.WriteLine(multiplication);
            Console.WriteLine(division);

            Console.ReadLine();
        }

        private static float Add()
        {
            float result;
            result = n1 + n2;

            return result;
        }

        private static float Substract()
        {
            return n1 - n2;
        }

        private static float Multiply()
        {
            return n1 * n2;
        }

        private static float Divide()
        {
            return n1 / n2;
        }
    }
}
