using Banks.Entities;

namespace Banks
{
    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void Notification(BankAccount bankAccount, Transaction transaction);
    }
}