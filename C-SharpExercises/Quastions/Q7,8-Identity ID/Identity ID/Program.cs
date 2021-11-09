using System;

namespace Identity_ID
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberStr = "";
            long numberLong = 0;
            do
            {
                Console.WriteLine("Enter your ID card Nummber");
                numberStr = Console.ReadLine();
                numberLong = Convert.ToInt64(numberStr);
                if (numberStr.Length != 10)
                {
                    Console.WriteLine("The number must have 10 digits");
                }
                else if (!CheckIdNumber(numberLong))
                {
                    Console.WriteLine("The number of your ID card is not valid");
                }
                else if (CheckIdNumber(numberLong))
                {
                    Console.WriteLine("The number of your ID card is valid");
                }
            } while (numberStr.Length != 10 || CheckIdNumber(numberLong) == false);
            
            CheckCity(numberStr);

        }
        public static bool CheckIdNumber(long number)
        {
            bool flag = false;
            long controlNumber = number%10;
            long num = (number - controlNumber) / 10;
            long newNum = num;
            long sum = 0;
            for (int i = 2; i < 11; i++)
            {
                long yekan = newNum % 10;
                sum += yekan * i;
                newNum = (newNum - yekan) / 10;
            }
            long rest = sum % 11;
            if (rest < 2 && rest == controlNumber)
            {
                flag = true;
            }
            if (rest >= 2 && controlNumber == 11-rest)
            {
                flag = true;
            }
            return flag;
        }
        
        public static void CheckCity(string number)
        {
            if (CheckIdNumber(Convert.ToInt64(number)))
            {
                string newNumber =number.Substring(0, 3);
                switch (newNumber)
                {
                    case "284":
                        Console.WriteLine("You were born in Salmas");
                        break;
                    case "001":
                    case "002":
                    case "003":
                    case "004":
                    case "005":
                    case "006":
                    case "007":
                        Console.WriteLine("You were born in Central Tehran");
                        break;
                    case "169":
                        Console.WriteLine("You were born in AzarShahr");
                        break;
                    case "171":
                        Console.WriteLine("You were born in BostanAbad");
                        break;
                    case "168":
                        Console.WriteLine("You were born in Bonab");
                        break;
                    case "136":
                    case "137":
                    case "138":
                        Console.WriteLine("You were born in Tabriz");
                        break;
                    case "505":
                        Console.WriteLine("You were born in Jolfa");
                        break;
                    case "567":
                        Console.WriteLine("You were born in Varzaghan");
                        break;

                    default:
                        Console.WriteLine("You were born in nowhere!!!!!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("The number is invalid");
            }
        }
    }
}
