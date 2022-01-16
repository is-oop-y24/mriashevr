using Banks.Entities;

namespace Banks.BankAccountTypes
{
    public class CreditBankAccount : BankAccount
    {
        public CreditBankAccount(Bank bank, User user)
            : base(bank, user)
        {
        }
    }
}