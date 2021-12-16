using System;
using System.Collections.Generic;
using System.IO;
using Banks.Tools;

namespace Banks.Entities
{
    public abstract class BankAccount
    {
        private int _maxTransferingForSuspiciousUsers = 30000;
        private Dictionary<Guid, int> _transactions;
        public BankAccount(Bank bank, User user)
        {
            User = user;
            PlusPercents = null;
            Id = Guid.NewGuid();
            MoneySum = 0;
            MoneyDebt = null;
            MinusPercents = null;
            _transactions = new Dictionary<Guid, int>();
        }

        public Guid Id { get; }
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

        public virtual BankAccount WithdrawMoney(int money)
        {
            if (MoneySum >= money)
            {
                MoneySum -= money;
                _transactions.Add(Guid.NewGuid(), money);
                return this;
            }

            throw new BanksException("not enough money");
        }

        public virtual BankAccount TransferMoney(BankAccount bankAccountBegin, BankAccount bankAccountEnd, int money)
        {
            int passport = bankAccountBegin.User.GetPassport();
            string address = bankAccountBegin.User.GetAddress();
            if (passport == default && address == null && money > _maxTransferingForSuspiciousUsers)
            {
                throw new BanksException("sus, passport required");
            }

            if (bankAccountBegin.MoneySum >= money)
            {
                bankAccountBegin.MoneySum -= money;
                Guid id = Guid.NewGuid();
                bankAccountBegin._transactions.Add(id, money);
                bankAccountEnd.MoneySum += money;
                bankAccountEnd._transactions.Add(id, money);
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
            var money = bankAccountBegin._transactions.GetValueOrDefault(transactionId);
            bankAccountBegin.TransferMoney(bankAccountEnd, bankAccountBegin, money);

            return bankAccountBegin;
        }
    }
}