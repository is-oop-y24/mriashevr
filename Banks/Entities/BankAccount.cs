using System;
using System.Collections.Generic;
using System.IO;
using Banks.Tools;

namespace Banks.Entities
{
    public abstract class BankAccount
    {
        private int _maxTransferingForSuspiciousUsers = 30000;
        public BankAccount(Bank bank, User user)
        {
            User = user;
            PlusPercents = null;
            Id = Guid.NewGuid();
            MoneySum = 0;
            MoneyDebt = null;
            MinusPercents = null;
            Transactions = new Dictionary<Guid, int>();
        }

        public Guid Id { get; }
        public int? MoneySum { get; private set; }
        public int? PlusPercents { get; private set; }
        public int? MoneyDebt { get; private set; }
        public int? MinusPercents { get; private set; }
        public User User { get; }
        public Dictionary<Guid, int> Transactions { get; }

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

        public BankAccount ChangePlusPercents(BankAccount bankAccount, int x)
        {
            bankAccount.PlusPercents = x;
            return bankAccount;
        }

        public BankAccount ChangeMinusPercents(BankAccount bankAccount, int x)
        {
            bankAccount.MinusPercents = x;
            return bankAccount;
        }

        public virtual BankAccount WithdrawMoney(BankAccount bankAccount, int money)
        {
            if (bankAccount.MoneySum >= money)
            {
                bankAccount.MoneySum -= money;
                bankAccount.Transactions.Add(Guid.NewGuid(), money);
                return bankAccount;
            }

            throw new BanksException("not enough money");
        }

        public virtual BankAccount TransferMoney(BankAccount bankAccountBegin, BankAccount bankAccountEnd, int money)
        {
            int x = bankAccountBegin.User.GetPassport();
            string x1 = bankAccountBegin.User.GetAddress();
            if (x == 0 && x1 == " " && money > _maxTransferingForSuspiciousUsers)
            {
                throw new BanksException("sus, passport required");
            }

            if (bankAccountBegin.MoneySum >= money)
            {
                bankAccountBegin.MoneySum -= money;
                Guid id = Guid.NewGuid();
                bankAccountBegin.Transactions.Add(id, money);
                bankAccountEnd.MoneySum += money;
                bankAccountEnd.Transactions.Add(id, money);
                return bankAccountBegin;
            }

            throw new BanksException("not enough money to complete the transfer");
        }

        public BankAccount TopUpMoney(BankAccount bankAccount, int money)
        {
            bankAccount.MoneySum += money;
            return bankAccount;
        }

        public BankAccount CancelTransaction(BankAccount bankAccountBegin, BankAccount bankAccountEnd, Guid transactionId)
        {
            var money = bankAccountBegin.Transactions.GetValueOrDefault(transactionId);
            bankAccountBegin.TransferMoney(bankAccountEnd, bankAccountBegin, money);

            return bankAccountBegin;
        }
    }
}