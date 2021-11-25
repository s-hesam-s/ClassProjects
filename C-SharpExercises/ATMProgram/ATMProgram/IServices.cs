using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProgram
{
    interface IServices
    {
        public List<Bank> AddBank();
        public void AtmOperations(List<Bank> ownBankList, List<Bank> desBankList);
    }
    class Services : IServices
    {
        public List<Bank> AddBank()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n-------------------------BANK LIST------------------------");
            Console.ResetColor();
            List<Bank> banks = new List<Bank>();
            string con;
            do
            {
                Bank bank = new Bank();
                Console.Write("\nEnter your bank's name: ");
                bank.Name = Console.ReadLine();
                Console.Write("\nEnter your bank's cardNum: ");
            Start:
                bank.CardNum = Console.ReadLine();
                foreach (var item in banks)
                {
                    if (item.CardNum == bank.CardNum)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nThis card number has been taken");
                        Console.ResetColor();
                        Console.Write("\nEnter new card number: ");
                        goto Start;
                    }
                }
                Console.Write("\nEnter your card's pass: ");
                bank.CardPass = Console.ReadLine();
                Console.Write("\nEnter your card's balance: $");
                bank.Balance = Bank.CheckDouble(Console.ReadLine());
                banks.Add(bank);
                foreach (var item in banks)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\n*************************************************");
                    Console.ResetColor();
                    Console.Write($"\nBank's Name: {item.Name}\n" +
                        $"Bank's Card Number: {item.CardNum}\n" +
                        $"Bank's Card Password: {item.CardPass}\n" +
                        $"Bank's Balance: ${item.Balance}");
                }
                Console.WriteLine("\n\nDo you want to continue? Yes/No");
                con = Console.ReadLine().ToLower();
                while (con != "no" && con != "yes")
                {
                    Console.WriteLine("\nEnter Yes or No");
                    con = Console.ReadLine();
                }
            } while (con == "yes");
            return banks;
        }

        public void AtmOperations(List<Bank> ownBankList, List<Bank> desBankList)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\n-------------------------WELCOME------------------------");
            Console.ResetColor();
            Atm atm = new Atm();
            string result = "";
            Bank bank;
            do
            {
                bank = atm.GetOwnBank(ownBankList);
                if (bank == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nCard number cannot be found");
                    Console.ResetColor();
                    Console.WriteLine("\n\nDo you want to try again? Yes/No");
                    result = Console.ReadLine().ToLower();
                    while (result != "no" && result != "yes")
                    {
                        Console.WriteLine("\nEnter Yes or No");
                        result = Console.ReadLine();
                    }
                }
                else
                {
                    break;
                }
            } while (result == "yes");

            if (bank == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nPlease take your card");
                Console.ResetColor();
            }
            else
            {
                int ctr = 2;
                bool check;
                do
                {
                    check = atm.CheckCardNumPass(bank);
                    if (!check && ctr != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\nPassword is wrong,you have {ctr} attempt(s)");
                        Console.ResetColor();
                    }
                    if (!check && ctr == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("\nYour card has been revoked");
                        Console.ResetColor();
                        break;
                    }
                    if (check)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nYou have been logged in successfully");
                        Console.ResetColor();
                        break;
                    }
                    ctr--;
                } while (!check);

                if (check)
                {
                Start2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\n*************************************************");
                    Console.ResetColor();
                    Console.WriteLine("\nWhich Services do you need?\n" +
                        "1-Transfer\n2-Withdraw\n3-Print Balance\n4-Change Password\n" +
                        "5-Last 10 Transactions\n6-Exit");
                Start:
                    string service = Console.ReadLine();
                    switch (service)
                    {
                        case "1":
                            string result2;
                            Bank desBank;
                            do
                            {
                                desBank = atm.GetDesBank(desBankList);
                                if (desBank == null)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("\nCard number cannot be found");
                                    Console.ResetColor();
                                    Console.WriteLine("\n\nDo you want to try again? Yes/No");
                                    result2 = Console.ReadLine().ToLower();
                                    while (result2 != "no" && result2 != "yes")
                                    {
                                        Console.WriteLine("\nEnter Yes or No");
                                        result2 = Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            } while (result2 == "yes");

                            if (desBank == null)
                            {
                                goto Start2;
                            }
                            else
                            {
                            Start3:
                                bool trs = atm.Transfer(bank, desBank);
                                if (!trs)
                                {
                                    string result3;
                                    Console.WriteLine("\n\nDo you want to try again?" +
                                    " Yes/No");
                                    result3 = Console.ReadLine();
                                    while (result3 != "no" && result3 != "yes")
                                    {
                                        Console.WriteLine("\nEnter Yes or No");
                                        result3 = Console.ReadLine();
                                    }
                                    if (result3 == "yes")
                                    {
                                        goto Start3;
                                    }
                                    else
                                    {
                                        goto Start2;
                                    }
                                }
                                else
                                {
                                    string result4;
                                    Console.WriteLine("\n\nDo you want to continue?" +
                                    " Yes/No");
                                    result4 = Console.ReadLine();
                                    while (result4 != "no" && result4 != "yes")
                                    {
                                        Console.WriteLine("\nEnter Yes or No");
                                        result4 = Console.ReadLine();
                                    }
                                    if (result4 == "yes")
                                    {
                                        goto Start2;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("Please take your card");
                                        Console.ResetColor();
                                    }
                                }
                            }
                            break;

                        case "2":
                            string result5;
                        Start4:
                            bool wid = atm.Withdraw(bank);
                            if (!wid)
                            {
                                Console.WriteLine("\n\nDo you want to try again?" +
                                " Yes/No");
                                result5 = Console.ReadLine();
                                while (result5 != "no" && result5 != "yes")
                                {
                                    Console.WriteLine("\nEnter Yes or No");
                                    result5 = Console.ReadLine();
                                }
                                if (result5 == "yes")
                                {
                                    goto Start4;
                                }
                                else
                                {
                                    goto Start2;
                                }
                            }
                            else
                            {
                                string result6;
                                Console.WriteLine("\n\nDo you want to continue?" +
                                " Yes/No");
                                result6 = Console.ReadLine();
                                while (result6 != "no" && result6 != "yes")
                                {
                                    Console.WriteLine("\nEnter Yes or No");
                                    result6 = Console.ReadLine();
                                }
                                if (result6 == "yes")
                                {
                                    goto Start2;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Please take your card");
                                    Console.ResetColor();
                                }
                            }
                            break;

                        case "3":
                            atm.PrintBalance(bank);
                            string result7;
                            Console.WriteLine("\n\nDo you want to continue?" +
                            " Yes/No");
                            result7 = Console.ReadLine();
                            while (result7 != "no" && result7 != "yes")
                            {
                                Console.WriteLine("\nEnter Yes or No");
                                result7 = Console.ReadLine();
                            }
                            if (result7 == "yes")
                            {
                                goto Start2;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Please take your card");
                                Console.ResetColor();
                            }
                            break;

                        case "4":
                            string result8;
                        Start5:
                            bool change = atm.ChangePass(bank);
                            if (!change)
                            {
                                Console.WriteLine("\n\nDo you want to try again?" +
                                " Yes/No");
                                result8 = Console.ReadLine();
                                while (result8 != "no" && result8 != "yes")
                                {
                                    Console.WriteLine("\nEnter Yes or No");
                                    result5 = Console.ReadLine();
                                }
                                if (result8 == "yes")
                                {
                                    goto Start5;
                                }
                                else
                                {
                                    goto Start2;
                                }
                            }
                            else
                            {
                                string result9;
                                Console.WriteLine("\n\nDo you want to continue?" +
                                " Yes/No");
                                result9 = Console.ReadLine();
                                while (result9 != "no" && result9 != "yes")
                                {
                                    Console.WriteLine("\nEnter Yes or No");
                                    result9 = Console.ReadLine();
                                }
                                if (result9 == "yes")
                                {
                                    goto Start2;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("Please take your card");
                                    Console.ResetColor();
                                }
                            }
                            break;

                        case "5":
                            atm.LastTenTrs(bank);
                            string result10;
                            Console.WriteLine("\n\nDo you want to continue?" +
                            " Yes/No");
                            result10 = Console.ReadLine();
                            while (result10 != "no" && result10 != "yes")
                            {
                                Console.WriteLine("\nEnter Yes or No");
                                result10 = Console.ReadLine();
                            }
                            if (result10 == "yes")
                            {
                                goto Start2;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Please take your card");
                                Console.ResetColor();
                            }
                            break;

                        case "6":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Please take your card");
                            Console.ResetColor();
                            break;

                        default:
                            Console.Write("\nEnter the right number: ");
                            goto Start;
                    }
                }
            }
        }
    }
}
