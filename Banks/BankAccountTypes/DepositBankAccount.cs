using System;
using Banks.Entities;
using Banks.Tools;

namespace Banks.BankAccountTypes
{
    public class DepositBankAccount : BankAccount
    {
        public DepositBankAccount(Bank bank, User user)
            : base(bank, user)
        {
        }

        public override BankAccount WithdrawMoney(int money)
        {
            throw new BanksException("Not able to withdraw money from deposit account");
        }

        public override BankAccount TransferMoney(BankAccount bankAccountEnd, int money)
        {
            throw new BanksException("Not able to transfer money from deposit account");
        }
    }
}