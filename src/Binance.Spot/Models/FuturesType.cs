namespace Binance.Spot.Models
{
    public readonly struct FuturesType
    {
        private FuturesType(short value)
        {
            this.Value = value;
        }

        public static FuturesType USDT_MARGINED_FUTURES => new FuturesType(1);
        public static FuturesType COIN_MARGINED_FUTURES => new FuturesType(2);

        public short Value { get; }

        public static implicit operator short(FuturesType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}