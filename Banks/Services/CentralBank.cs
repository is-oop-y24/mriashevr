using System;
using System.Collections.Generic;
using Banks.Entities;
using Banks.Tools;

namespace Banks.Services
{
    public class CentralBank
    {
        private List<Bank> _banks = new List<Bank>();

        public User CreateUser(string name, string surname, Bank bank)
        {
            var user = new User(name, surname, null, default);
            user.AddListBank(bank);
            bank.Users.Add(user);
            return user;
        }

        public Bank CreateBank(string name)
        {
            var bank = new Bank(name);
            _banks.Add(bank);
            return bank;
        }

        public User AddClientAddress(User user, string address)
        {
            var builder = new UserBuilder();
            var userBuilder = new UserBuilder();
            userBuilder.AddName(user.GetFirstName());
            userBuilder.AddSurname(user.GetLastName());
            userBuilder.AddAddress(address);
            userBuilder.AddPassport(user.GetPassport());
            User newUser = userBuilder.Build();
            return newUser;
        }

        public User AddClientPassport(User user, int passport)
        {
            var builder = new UserBuilder();
            var userBuilder = new UserBuilder();
            userBuilder.AddName(user.GetFirstName());
            userBuilder.AddSurname(user.GetLastName());
            userBuilder.AddAddress(user.GetAddress());
            userBuilder.AddPassport(passport);
            User newUser = userBuilder.Build();
            return newUser;
        }

        public void PercentsAccrual(DateTime begin, DateTime end)
        {
            TimeSpan timePassed = end - begin;
            int x = (int)timePassed.TotalDays;
            foreach (Bank bank in _banks)
            {
                foreach (BankAccount bankAccount in bank.BankAccounts)
                {
                    int? creditPercent = bankAccount.MinusPercents;
                    if (creditPercent != 0)
                    {
                        bankAccount.AddTimePassPercentsM(bankAccount, x / 30);
                    }

                    int? debitDepositPercent = bankAccount.PlusPercents;
                    if (debitDepositPercent != 0)
                    {
                        bankAccount.AddTimePassPercentsP(bankAccount, x / 30);
                    }
                }
            }
        }
    }
}