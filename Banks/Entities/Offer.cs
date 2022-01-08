namespace Banks.Entities
{
    public class Offer
    {
        private static int _number = 0;
        public Offer(int percent)
        {
            OfferNumber = ++_number;
            Percentage = percent;
        }

        public int Percentage { get; }
        public int OfferNumber { get; }
    }
}