using System.IO;
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
        public void TransferMoneyFromSuspiciousAccount()
        {
            var bank = _centralBank.CreateBank("tink");
            bank.AddNewOffer(bank, 3);
            var user1 = _centralBank.CreateUser("maks", "maks", bank);
            var user2 = _centralBank.CreateUser("den", "maks", bank);
            var ba1 = bank.CreateDebitBankAccount(bank, 1, user1);
            var ba2 = bank.CreateDebitBankAccount(bank, 1, user2);
            ba1.TopUpMoney(ba1, 50000);
            Assert.Catch<BanksException>(() =>
            {
                ba1.TransferMoney(ba1, ba2, 31000);
            });
        }
    }
}       