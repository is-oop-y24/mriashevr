using System;

namespace Banks.Entities
{
    public class Transaction
    {
        public Transaction(BankAccount accountFrom, BankAccount accountTo, int sum)
        {
            Id = Guid.NewGuid();
            AccountFrom = accountFrom;
            AccountTo = accountTo;
            Sum = sum;
            ProceededOrDeclined = true;
        }

        public BankAccount AccountFrom { get; }
        public BankAccount AccountTo { get; }
        public int Sum { get; }
        public bool ProceededOrDeclined { get; private set; }
        public Guid Id { get; }

        public void DeclineTransaction()
        {
            ProceededOrDeclined = false;
        }
    }
}