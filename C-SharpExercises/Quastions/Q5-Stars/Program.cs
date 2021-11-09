using System;

namespace Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input number of rows : ");
            int rows = Convert.ToInt32(Console.ReadLine());
            for (int i = rows; i >= 1; i--)
            {
                for (int k = i; k <= rows; k++)
                {
                    Console.Write(" ");
                }

                for (int j = i; j >= 1; j--)
                {
                    Console.Write("* ");
                }

                Console.Write("\n");
            }
        }
    }
}
