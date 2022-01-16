using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Banks.BankAccountTypes;
using Banks.Tools;

namespace Banks.Entities
{
    public class Bank : IObservable
    {
        public Bank(string name)
        {
            Name = name;
            Users = new List<User>();
            BankAccounts = new List<BankAccount>();
            Offers = new List<Offer>();
            Transactions = new List<Transaction>();
            ObserverNotifications = new List<IObserver>();
        }

        public List<Offer> Offers { get; }
        public string Name { get; }
        public List<User> Users { get; }
        public List<BankAccount> BankAccounts { get; }
        public List<Transaction> Transactions { get; }
        public List<IObserver> ObserverNotifications { get; }

        public void AddNewOffer(int percentage)
        {
            Offers.Add(new Offer(percentage));
        }

        public BankAccount CreateDepositBankAccount(Bank bank, int offerNumber, User user)
        {
            var deposit = new DepositBankAccount(bank, user);
            deposit.ChangePlusPercents(bank.Offers.FirstOrDefault(offer => offer.OfferNumber == offerNumber).Percentage);
            return deposit;
        }

        public BankAccount CreateDebitBankAccount(Bank bank, int offerNumber, User user)
        {
            var debit = new DebitBankAccount(bank, user);
            debit.ChangePlusPercents(bank.Offers.FirstOrDefault(offer => offer.OfferNumber == offerNumber).Percentage);
            return debit;
        }

        public BankAccount CreateCreditBankAccount(Bank bank, int offerNumber, User user)
        {
            var credit = new DepositBankAccount(bank, user);
            credit.ChangeMinusPercents(credit, bank.Offers.FirstOrDefault(offer => offer.OfferNumber == offerNumber).Percentage);
            return credit;
        }

        public Transaction CancelTransaction(Guid transactionId)
        {
            Transaction transaction = Transactions.FirstOrDefault(transaction => transaction.Id == transactionId);

            if (transaction == null)
            {
                throw new BanksException("transaction not found");
            }

            if (transaction.MayBeCanceled)
            {
                if (transaction.AccountTo == null)
                {
                    transaction.AccountFrom.TopUpMoney(transaction.Sum);
                    transaction.DeclineTransaction();
                    return transaction;
                }

                if (transaction.AccountFrom == null)
                {
                    transaction.AccountTo.WithdrawMoney(transaction.Sum);
                    transaction.DeclineTransaction();
                    return transaction;
                }

                transaction.AccountFrom.TransferMoney(transaction.AccountFrom, transaction.Sum);
                transaction.DeclineTransaction();
            }

            return transaction;
        }

        public void AddObserver(IObserver observer)
        {
            ObserverNotifications.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            ObserverNotifications.Remove(observer);
        }

        public void Notification(BankAccount bankAccount, Transaction transaction)
        {
            foreach (var observer in ObserverNotifications)
            {
                observer.Notify(bankAccount, transaction);
            }
        }
    }
}