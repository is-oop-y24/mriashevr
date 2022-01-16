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
            Bank _bank = _centralBank.CreateBank("tink");
            _bank.AddNewOffer(3);
            User user1 = _centralBank.CreateUser("maks", "maks", _bank);
            User user2 = _centralBank.CreateUser("den", "maks", _bank);
            BankAccount ba1 = _bank.CreateDebitBankAccount(_bank, 3, user1);
            BankAccount ba2 = _bank.CreateDebitBankAccount(_bank, 3, user2);
            ba1.TopUpMoney(50000);
            Assert.Catch<BanksException>(() =>
            {
                ba1.TransferMoney(ba2, 31000);
            });
        }

        [Test]
        public void TopUpMoney_CheckBalance()
        {
            Bank _bank = _centralBank.CreateBank("tink");
            _bank.AddNewOffer(3);
            User user1 = _centralBank.CreateUser("maks", "maks", _bank);
            BankAccount account = _bank.CreateDebitBankAccount(_bank, 1, user1);
            const int amount = 1000;
            account.TopUpMoney(amount);
            account.TopUpMoney(amount);
            account.TopUpMoney(amount);
            Assert.AreEqual(amount * 3, account.MoneySum);
        }
        
        [Test]
        public void WithdrawMoney_CheckBalance()
        {
            Bank _bank = _centralBank.CreateBank("tink");
            _bank.AddNewOffer(3);
            User user1 = _centralBank.CreateUser("maks", "maks", _bank);
            BankAccount account = _bank.CreateDebitBankAccount(_bank, 4, user1);
            const int amount = 1000;
            account.TopUpMoney(amount);
            account.WithdrawMoney(amount);
            account.TopUpMoney(amount);
            Assert.AreEqual(amount, account.MoneySum);
        }

        [Test]
        public void TransferMoney_CheckBalances()
        {
            Bank _bank = _centralBank.CreateBank("tink");
            _bank.AddNewOffer(3);
            User user1 = _centralBank.CreateUser("maks", "maks", _bank);
            BankAccount account = _bank.CreateDebitBankAccount(_bank, 2, user1);
            User user2 = _centralBank.CreateUser("den", "maks", _bank);
            BankAccount account2 = _bank.CreateDebitBankAccount(_bank, 2, user2);
            account.TopUpMoney(5000);
            account.TransferMoney(account2, 1000);
            Assert.AreEqual(4000, account.MoneySum);
            Assert.AreEqual(1000, account2.MoneySum);
        }
        
    }
}       