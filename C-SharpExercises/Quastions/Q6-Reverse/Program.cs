using System;

namespace Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Enter a number");
            string number = Console.ReadLine();

            char[] numberArray = number.ToCharArray();
            Array.Reverse(numberArray);
            System.Console.Write("The reverse number is: ");
            Console.WriteLine(numberArray);
        }
    }
}
