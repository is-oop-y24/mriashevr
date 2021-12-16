using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Banks.BankAccountTypes;

namespace Banks.Entities
{
    public class Bank
    {
        private int a = 1;
        public Bank(string name)
        {
            Name = name;
            Users = new List<User>();
            BankAccounts = new List<BankAccount>();
            Offers = new Dictionary<int, int>();
        }

        public Dictionary<int, int> Offers { get; }
        public string Name { get; }
        public List<User> Users { get; }
        public List<BankAccount> BankAccounts { get; }

        public void AddNewOffer(Bank bank, int percentage)
        {
            bank.Offers[a] = percentage;
            a++;
        }

        public BankAccount CreateDepositBankAccount(Bank bank, int offernumber, User user)
        {
            var deposit = new DepositBankAccount(bank, user);
            deposit.ChangePlusPercents(deposit, bank.Offers[offernumber]);
            return deposit;
        }

        public BankAccount CreateDebitBankAccount(Bank bank, int offernumber, User user)
        {
            var debit = new DebitBankAccount(bank, user);
            debit.ChangePlusPercents(debit, bank.Offers[offernumber]);
            return debit;
        }

        public BankAccount CreateCreditBankAccount(Bank bank, int offernumber, User user)
        {
            var credit = new DepositBankAccount(bank, user);
            credit.ChangeMinusPercents(credit, bank.Offers[offernumber]);
            return credit;
        }
    }
}