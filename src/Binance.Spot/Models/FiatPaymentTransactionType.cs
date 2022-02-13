namespace Binance.Spot.Models
{
    public readonly struct FiatPaymentTransactionType
    {
        private FiatPaymentTransactionType(short value)
        {
            this.Value = value;
        }

        public static FiatPaymentTransactionType BUY => new FiatPaymentTransactionType(0);
        public static FiatPaymentTransactionType SELL => new FiatPaymentTransactionType(1);

        public short Value { get; }

        public static implicit operator short(FiatPaymentTransactionType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}