using Banks.Entities;

namespace Banks.BankAccountTypes
{
    public class DebitBankAccount : BankAccount
    {
        public DebitBankAccount(Bank bank, User user)
            : base(bank, user)
        {
        }
    }
}