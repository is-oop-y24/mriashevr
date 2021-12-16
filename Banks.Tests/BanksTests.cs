using System;
using System.IO;
using Banks.BankAccountTypes;
using Banks.Entities;
using Banks.Services;
using Banks.Tools;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Banks.Tests
{
    public class BackupTests
    {
        private CentralBank _centralBank;

        [SetUp]
        public void Setup()
        {
            _centralBank = new CentralBank();
        }

        [Test]
        public void TransferMoneyFromSuspiciousAccount_CatchError()
        {
            Bank bank = _centralBank.CreateBank("tink");
            bank.AddNewOffer(bank, 3);
            User user1 = _centralBank.CreateUser("maks", "maks", bank);
            User user2 = _centralBank.CreateUser("den", "maks", bank);
            BankAccount ba1 = bank.CreateDebitBankAccount(bank, 1, user1);
            BankAccount ba2 = bank.CreateDebitBankAccount(bank, 1, user2);
            ba1.TopUpMoney(ba1, 50000);
            Assert.Catch<BanksException>(() =>
            {
                ba1.TransferMoney(ba1, ba2, 31000);
            });
        }

        [Test]
        public void TopUpMoney_CheckBalance()
        {
            var bank = _centralBank.CreateBank("tink");
            bank.AddNewOffer(bank, 3);
            var user1 = _centralBank.CreateUser("maks", "maks", bank);
            var account = bank.CreateDebitBankAccount(bank, 1, user1);
            const int amount = 1000;
            account.TopUpMoney(account, amount);
            account.TopUpMoney(account, amount);
            account.TopUpMoney(account, amount);
            Assert.AreEqual(amount * 3, account.MoneySum);
        }
        
        [Test]
        public void WithdrawMoney_CheckBalance()
        {
            var bank = _centralBank.CreateBank("tink");
            bank.AddNewOffer(bank, 3);
            var user1 = _centralBank.CreateUser("maks", "maks", bank);
            var account = bank.CreateDebitBankAccount(bank, 1, user1);
            const int amount = 1000;
            account.TopUpMoney(account, amount);
            account.WithdrawMoney(amount);
            account.TopUpMoney(account, amount);
            Assert.AreEqual(amount, account.MoneySum);
        }

        [Test]
        public void TransferMoney_CheckBalances()
        {
            var bank = _centralBank.CreateBank("tink");
            bank.AddNewOffer(bank, 3);
            var user1 = _centralBank.CreateUser("maks", "maks", bank);
            var account = bank.CreateDebitBankAccount(bank, 1, user1);
            var user2 = _centralBank.CreateUser("den", "maks", bank);
            var account2 = bank.CreateDebitBankAccount(bank, 1, user2);
            account.TopUpMoney(account, 5000);
            account.TransferMoney(account, account2, 1000);
            Assert.AreEqual(4000, account.MoneySum);
            Assert.AreEqual(1000, account2.MoneySum);
        }
        
    }
}       