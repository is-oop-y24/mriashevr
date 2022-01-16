using Banks.Entities;

namespace Banks
{
    public interface IObserver
    {
        void Notify(BankAccount bankAccount, Transaction transaction);
    }
}