using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProgram
{
    interface IAtm
    {
        public Bank GetOwnBank(List<Bank> ownBankList);
        public Bank GetDesBank(List<Bank> desBankList);
        public bool CheckCardNumPass(Bank bank);
        public bool Transfer(Bank myBank, Bank desBank);
        public bool Withdraw(Bank bank);
        public bool ChangePass(Bank bank);
        public void PrintBalance(Bank bank);
        public void LastTenTrs(Bank bank);

    }
    class Atm : IAtm
    {
        public Bank GetOwnBank(List<Bank> ownBankList)
        {
            Console.Write("\nEnter your card number: ");
            string cardNum = Console.ReadLine();
            Bank bank = ownBankList.SingleOrDefault(bank => bank.CardNum == cardNum);

            return bank;
        }
        public Bank GetDesBank(List<Bank> desBankList)
        {
            Console.Write("\nEnter the destination card number: ");
            string desCardNum = Console.ReadLine();
            Bank bank = desBankList.SingleOrDefault(bank => bank.CardNum == desCardNum);

            return bank;
        }

        public bool CheckCardNumPass(Bank bank)
        {
            Console.Write("\nEnter your pass:  ");
            string pass = Console.ReadLine();
            return bank.CardPass == pass ? true : false;
        }

        public bool Transfer(Bank myBank, Bank desBank)
        {
            Console.Write("\nEnter the amount you want to transfer:  ");
            double amount = Convert.ToDouble(Console.ReadLine());
            if (amount > myBank.Balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nYour balance is not enough");
                Console.ResetColor();
                return false;
            }
            else
            {
                myBank.Balance -= amount;
                desBank.Balance += amount;
                Transaction transaction = new Transaction();
                Guid obj = Guid.NewGuid();
                transaction.Id = obj.ToString();
                transaction.Withdraw = amount;
                transaction.Deposit = 0;
                transaction.DateTime = DateTime.Now;
                myBank.Transactions.Add(transaction);

                Transaction desTransaction = new Transaction();
                Guid desObj = Guid.NewGuid();
                desTransaction.Id = desObj.ToString();
                desTransaction.Withdraw = 0;
                desTransaction.Deposit = amount;
                desTransaction.DateTime = DateTime.Now;
                desBank.Transactions.Add(desTransaction);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\nTransfer is successful");
                Console.ResetColor();
                Console.Write($"\nYour tracking code is: {transaction.Id}");
                return true;
            }
        }
        public bool Withdraw(Bank bank)
        {
            Console.Write("\nEnter the amount you want to withdraw: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            if (amount > bank.Balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nYour balance is not enough");
                Console.ResetColor();
                return false;
            }
            else
            {
                bank.Balance -= amount;
                Transaction transaction = new Transaction();
                Guid obj = Guid.NewGuid();
                transaction.Id = obj.ToString();
                transaction.Withdraw = amount;
                transaction.Deposit = 0;
                transaction.DateTime = DateTime.Now;
                bank.Transactions.Add(transaction);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\nWithdrawal is successful");
                Console.ResetColor();
                Console.Write($"\nYour tracking code is: {transaction.Id}");
                return true;
            }
        }
        public void PrintBalance(Bank bank)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n*************************************************");
            Console.ResetColor();
            Console.Write($"\nYour balance is: {bank.Balance}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n*************************************************");
            Console.ResetColor();
        }

        public bool ChangePass(Bank bank)
        {
            Console.Write("\nEnter your old password: ");
            string oldPass = Console.ReadLine();
            if (oldPass != bank.CardPass)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nEntered password is incorrect");
                Console.ResetColor();
                return false;
            }
            else
            {
                Console.Write("\nEnter your new password: ");
                string newPass = Console.ReadLine();
                Console.Write("\nRe-enter the new password: ");
                string newPass2 = Console.ReadLine();
                if (newPass != newPass2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nRe-entered password is not match whith new password");
                    Console.ResetColor();
                    return false;
                }
                else
                {
                    bank.CardPass = newPass;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nYor password has changed successfully");
                    Console.ResetColor();
                    return true;
                }
            }
        }

        public void LastTenTrs(Bank bank)
        {
            List<Transaction> transactions = bank.Transactions;
            foreach (Transaction transaction in transactions.TakeLast(10))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n*************************************************");
                Console.ResetColor();
                Console.Write($"\nTransaction Id: {transaction.Id}\n" +
                $"Transaction Date: {transaction.DateTime.ToLongDateString()}\n" +
                $"Transaction Time: {transaction.DateTime.ToLongTimeString()}\n" +
                $"Withdrawal Amount: {transaction.Withdraw}\n" +
                $"Deposit Amount: {transaction.Deposit}");
            }
        }
    }
}
