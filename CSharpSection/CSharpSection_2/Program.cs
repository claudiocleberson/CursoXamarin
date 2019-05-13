using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSection_2.Classes;

namespace CSharpSection_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(SimpleMath.Division(432.23f, 54523.2f));

            //IOperations am = new AdvancedMath();

            //Console.WriteLine(" Remainder: " + am.Remainder(7, 3));

            //BankAccount bankAccount1 = new BankAccount(124321.32f, "Jane Doe");

            //Console.WriteLine(bankAccount1.Balance);

            //ChildrenBankAccount bankAccount2 = new ChildrenBankAccount(1321.43f, "John Doe","Jane Doe");

            //Console.WriteLine(bankAccount1.AddBalance(100f));

            //Console.WriteLine(bankAccount2.AddBalance(-1421.43f, true));

            GetData();

            Console.ReadLine();
        }

        async static void GetData()
        {
            BankAccount bankAccount = new BankAccount(589990f, "Jane Doe");

            Console.WriteLine(" Awaint connections.... ");

            var result = await bankAccount.GetData();

            Console.WriteLine(result);
        }
    }

    interface IOperations
    {
        float Remainder(float dividend, float divisor);
    }

    public class SimpleMath
    {
        public static float Add(float n1, float n2)
        {
            return n1 + n2;
        }

        public static float Substract(float n1, float n2)
        {
            return n1 - n2;
        }

        public static float Multiplication(float n1, float n2)
        {
            return n1 * n2;
        }

        public static float Division(float n1, float n2)
        {
            return n1 / n2;
        }
    }

    public class AdvancedMath : SimpleMath, IOperations
    {
        public float Remainder(float dividend, float divisor)
        {
            return dividend % divisor;
        }
    }

}
