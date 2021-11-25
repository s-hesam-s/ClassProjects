using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProgram
{
    class Bank
    {
        public Bank()
        {
            Transactions = new List<Transaction>();
        }
        string _name;
        public string Name
        {
            get { return _name; }
            set
            {
            Start:
                while (string.IsNullOrEmpty(value))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Enter Name!!!!");
                    value = Console.ReadLine();
                    Console.ResetColor();
                }
                foreach (var ch in value)
                {
                    if (!Char.IsLetter(ch))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nAll characters must be letter");
                        Console.ResetColor();
                        Console.Write("\nEnter new name: ");
                        value = Console.ReadLine();
                        goto Start;
                    }
                }
                _name = value;
            }
        }
        string _cardNum;
        public string CardNum
        {
            get { return _cardNum; }
            set
            {
            Start:
                while (value.Length != 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nCard number must have 8 digits");
                    Console.ResetColor();
                    Console.Write("\nEnter new card number: ");
                    value = Console.ReadLine();
                }
                foreach (var ch in value)
                {
                    if (!Char.IsNumber(ch))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nAll characters must be digits");
                        Console.ResetColor();
                        Console.Write("\nEnter new card number: ");
                        value = Console.ReadLine();
                        goto Start;
                    }
                }
                _cardNum = value;
            }
        }
        string _cardPass;
        public string CardPass
        {
            get { return _cardPass; }
            set
            {
            Start2:
                while (value.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nCard'password must have 4 digits");
                    Console.ResetColor();
                    Console.Write("\nEnter new card number: ");
                    value = Console.ReadLine();
                }
                foreach (var ch in value)
                {
                    if (!Char.IsNumber(ch))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nAll characters must be digits");
                        Console.ResetColor();
                        Console.Write("\nEnter new card number: ");
                        value = Console.ReadLine();
                        goto Start2;
                    }
                }
                _cardPass = value;
            }
        }
        double _balance;
        public double Balance
        {
            get { return _balance; }
            set
            {
                while (value < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nBalance cannot be negative");
                    Console.ResetColor();
                    Console.Write("\nEnter positive balance: $");
                    value = Bank.CheckDouble(Console.ReadLine());
                }
                _balance = value;
            }
        }
        public List<Transaction> Transactions { get; set; }
        public static double CheckDouble(string number)
        {
            double result;
            while (!double.TryParse(number, out result))
            {
                Console.Write("\nEnter a valid number: $");
                number = Console.ReadLine();
            }
            return result;
        }
    }
}
