using System;

namespace Identity_ID_For_Legal_People
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberStr = "";
            do
            {
                Console.WriteLine("Enter your legal ID number");
                numberStr = Console.ReadLine().Trim();
                if (numberStr.Length != 11)
                {
                    Console.WriteLine("The number must have 11 digits");
                }
                else if (!CheckLegalIdNumber(numberStr))
                {
                    Console.WriteLine("The number of your legal ID is not valid");
                }
                else if (CheckLegalIdNumber(numberStr))
                {
                    Console.WriteLine("The number of your legal ID is valid");
                }
            } while (numberStr.Length != 11 || CheckLegalIdNumber(numberStr) == false);

        }

        public static bool CheckLegalIdNumber(string number)
        {
            bool flag = false;
            int controlNumber = Convert.ToInt32(number.Substring(10));
            string newNum = number.Substring(0, 10);
            int dahganPlusTwo = Convert.ToInt32(newNum.Substring(9)) + 2;
            int[] array = new int[10];
            for (int i = 0; i < 10; i++)
            {
                array[i] = Convert.ToInt32(newNum.Substring(i, 1)) + dahganPlusTwo;
            }
            int sum = (array[0] + array[5]) * 29 + (array[1] + array[6]) * 27 + (array[2] + array[7]) * 23 +
                      (array[3] + array[8]) * 19 + (array[4] + array[9]) * 17;
            int rest = sum % 11;
            if (rest == 10)
            {
                rest = 0;
            }
            if (rest == controlNumber)
            {
                flag = true;
            }
            return flag;
        }
    }
}
