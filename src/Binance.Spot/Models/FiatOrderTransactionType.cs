namespace Binance.Spot.Models
{
    public readonly struct FiatOrderTransactionType
    {
        private FiatOrderTransactionType(short value)
        {
            this.Value = value;
        }

        public static FiatOrderTransactionType DEPOSIT => new FiatOrderTransactionType(0);
        public static FiatOrderTransactionType WITHDRAW => new FiatOrderTransactionType(1);

        public short Value { get; }

        public static implicit operator short(FiatOrderTransactionType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}