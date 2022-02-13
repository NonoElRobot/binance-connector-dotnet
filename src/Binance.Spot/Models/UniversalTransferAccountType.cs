namespace Binance.Spot.Models
{
    public readonly struct UniversalTransferAccountType
    {
        private UniversalTransferAccountType(string value)
        {
            this.Value = value;
        }

        public static UniversalTransferAccountType SPOT => new UniversalTransferAccountType("SPOT");
        public static UniversalTransferAccountType USDT_FUTURE => new UniversalTransferAccountType("USDT_FUTURE");
        public static UniversalTransferAccountType COIN_FUTURE => new UniversalTransferAccountType("COIN_FUTURE");

        public string Value { get; }

        public static implicit operator string(UniversalTransferAccountType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}