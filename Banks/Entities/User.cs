using System.Collections.Generic;
using System.Security.Cryptography;
using Banks.Tools;
using Microsoft.VisualBasic.CompilerServices;

namespace Banks.Entities
{
    public class User
    {
        private string _name;
        private string _surname;
        private string _address;
        private int _passport;
        private List<Bank> _banks;
        public User(string name, string surname, string address, int passport)
        {
            _name = name;
            _surname = surname;
            _address = address;
            _passport = passport;
            _banks = new List<Bank>();
        }

        public UserBuilder ToBuilder(UserBuilder clientBuilder)
        {
            clientBuilder.AddName(_name);
            clientBuilder.AddSurname(_surname);
            clientBuilder.AddAddress(_address);
            clientBuilder.AddPassport(_passport);
            return clientBuilder;
        }

        public string SetAddress(string address)
        {
            _address = address;
            return _address;
        }

        public int? SetPassport(int passport)
        {
            _passport = passport;
            return _passport;
        }

        public string GetFirstName()
        {
            return _name;
        }

        public string GetLastName()
        {
            return _surname;
        }

        public string GetAddress()
        {
            return _address;
        }

        public int GetPassport()
        {
            return _passport;
        }

        public List<Bank> GetBank()
        {
            return _banks;
        }

        public List<Bank> AddListBank(Bank bank)
        {
            _banks.Add(bank);
            return _banks;
        }
    }
}