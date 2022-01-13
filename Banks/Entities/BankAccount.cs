using System;
using System.Collections.Generic;
using System.IO;
using Banks.Tools;

namespace Banks.Entities
{
    public abstract class BankAccount : IObserver
    {
        private int _maxTransferingForSuspiciousUsers = 30000;
        public BankAccount(Bank bank, User user)
        {
            User = user;
            Bank = bank;
            PlusPercents = 1;
            Id = Guid.NewGuid();
            MoneySum = 0;
            MoneyDebt = null;
            MinusPercents = null;
        }

        public Guid Id { get; }
        public Bank Bank { get; }
        public int? MoneySum { get; private set; }
        public int? PlusPercents { get; private set; }
        public int? MoneyDebt { get; private set; }
        public int? MinusPercents { get; private set; }
        public User User { get; }

        public BankAccount AddTimePassPercentsM(BankAccount bankAccount, int month)
        {
            bankAccount.MoneyDebt += bankAccount.MoneyDebt * bankAccount.MinusPercents;
            return bankAccount;
        }

        public BankAccount AddTimePassPercentsP(BankAccount bankAccount, int month)
        {
            bankAccount.MoneySum += bankAccount.MoneySum * bankAccount.PlusPercents;
            return bankAccount;
        }

        public BankAccount ChangePlusPercents(int x)
        {
            PlusPercents = x;
            return this;
        }

        public BankAccount ChangeMinusPercents(BankAccount bankAccount, int x)
        {
            bankAccount.MinusPercents = x;
            return bankAccount;
        }

        public virtual BankAccount WithdrawMoney(int money)
        {
            if (MoneySum >= money)
            {
                MoneySum -= money;
                Bank.Transactions.Add(new Transaction(this, null, money));
                return this;
            }

            throw new BanksException("not enough money");
        }

        public virtual BankAccount TransferMoney(BankAccount bankAccountEnd, int money)
        {
            if (!User.Validation() && money > _maxTransferingForSuspiciousUsers)
            {
                throw new BanksException("sus, passport required");
            }

            if (MoneySum >= money)
            {
                MoneySum -= money;
                Guid id = Guid.NewGuid();
                Bank.Transactions.Add(new Transaction(this, bankAccountEnd, money));
                bankAccountEnd.MoneySum += money;
                return this;
            }

            throw new BanksException("not enough money to complete the transfer");
        }

        public BankAccount TopUpMoney(int money)
        {
            MoneySum += money;
            Bank.Transactions.Add(new Transaction(null, this, money));
            return this;
        }

        public void Notify(BankAccount bankAccount, Transaction transaction)
        {
            Console.WriteLine("The transaction completed:" + transaction);
        }
    }
}