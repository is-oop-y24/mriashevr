using System;

using System.Collections.Generic;
using Banks.Entities;

namespace Banks.Tools
{
    public class UserBuilder
    {
        private string _name;
        private string _surname;
        private string _address;
        private int _passport;
        private List<BankAccount> _listAccounts;

        public UserBuilder AddName(string name)
        {
            _name = name;
            return this;
        }

        public UserBuilder AddSurname(string surname)
        {
            _surname = surname;
            return this;
        }

        public UserBuilder AddAddress(string address)
        {
            _address = address;
            return this;
        }

        public UserBuilder AddPassport(int passport)
        {
            _passport = passport;
            return this;
        }

        public UserBuilder AddListAccounts(List<BankAccount> bankAccounts)
        {
            _listAccounts = bankAccounts;
            return this;
        }

        public User Build()
        {
            User finalUser = new User(_name, _surname, _address, _passport);
            return finalUser;
        }
    }
}