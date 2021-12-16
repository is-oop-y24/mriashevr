using System;
using Banks.Entities;
using Banks.Services;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            CentralBank centralBank = new CentralBank();
            var bank = centralBank.CreateBank("DVBank");
            bank.AddNewOffer(bank, 3);
            bank.AddNewOffer(bank, 7);
            var transferingUser = centralBank.CreateUser("hope", "itdwork", bank);
            var trba = bank.CreateDebitBankAccount(bank, 2, transferingUser);
            Console.WriteLine("Would you like to open a bank account in DV Bank?");
            Console.WriteLine("1 - Yes");
            Console.WriteLine("2 - No");
            string x = Console.ReadLine();
            if (x == "1")
            {
                Console.WriteLine("Please, enter your name");
                string name = Console.ReadLine();
                Console.WriteLine("Plz, enter your surname");
                string surname = Console.ReadLine();

                var user = centralBank.CreateUser(name, surname, bank);

                Console.WriteLine("Would you like to enter address data?");
                var a = Console.ReadLine();
                if (a == "yes")
                {
                    string address = Console.ReadLine();
                    user.SetAddress(address);
                }

                Console.WriteLine("Would you like to enter passport data?");
                var b = Console.ReadLine();
                if (b == "yes")
                {
                    string q = Console.ReadLine();
                    int passport = int.Parse(q);
                    user.SetPassport(passport);
                }

                Console.WriteLine("What kind of account you want? 1 - Credit, 2 - Debit, 3 - Deposit");
                string account = Console.ReadLine();
                BankAccount bankAccount = null;

                if (account == "1")
                {
                    Console.WriteLine("Please choose an offer for credit account: 1 -" + bank.Offers[1] + "2 - " +
                                      bank.Offers[2]);
                    string c = Console.ReadLine();
                    if (c == "1")
                    {
                        bankAccount = bank.CreateCreditBankAccount(bank, bank.Offers[1], user);
                    }
                    else
                    {
                        bankAccount = bank.CreateCreditBankAccount(bank, bank.Offers[2], user);
                    }

                    Console.WriteLine("Perfect, now you have a credit card");
                }
                else if (account == "3")
                {
                    Console.WriteLine("Please choose an offer for deposit account: 1 -" + bank.Offers[1] + "2 - " +
                                      bank.Offers[2]);
                    string c = Console.ReadLine();
                    if (c == "1")
                    {
                        bankAccount = bank.CreateDepositBankAccount(bank, bank.Offers[1], user);
                    }
                    else
                    {
                        bankAccount = bank.CreateDepositBankAccount(bank, bank.Offers[2], user);
                    }

                    Console.WriteLine("Perfect, now you have a deposit card");
                }
                else if (account == "2")
                {
                    bankAccount = bank.CreateDebitBankAccount(bank, 1, user);
                    Console.WriteLine("Perfect, now you have a debit card");
                }

                Console.WriteLine("Now you can do operations with your card. 1 - TopUp, 2 - Withdraw, 3 - Transfer");
                string operation = Console.ReadLine();
                if (operation == "1")
                {
                    Console.WriteLine("Enter sum you want to top up");
                    string m = Console.ReadLine();
                    int money = int.Parse(m);
                    bankAccount.TopUpMoney(bankAccount, money);
                }
                else if (operation == "2")
                {
                     Console.WriteLine("Enter sum you want to withdraw");
                     string m = Console.ReadLine();
                     int money = int.Parse(m);
                     bankAccount.WithdrawMoney(money);
                }
                else if (operation == "3")
                {
                     Console.WriteLine("Enter sum you want to transfer");
                     string m = Console.ReadLine();
                     int money = int.Parse(m);
                     bankAccount.TransferMoney(bankAccount, trba, money);
                }
            }
        }
    }
}
