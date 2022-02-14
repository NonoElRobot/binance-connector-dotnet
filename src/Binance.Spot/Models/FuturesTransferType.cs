namespace Binance.Spot.Models
{
    public readonly struct FuturesTransferType
    {
        private FuturesTransferType(short value)
        {
            this.Value = value;
        }

        public static FuturesTransferType SPOT_TO_USDT_MARGINED_FUTURES => new FuturesTransferType(1);
        public static FuturesTransferType USDT_MARGINED_FUTURES_TO_SPOT => new FuturesTransferType(2);
        public static FuturesTransferType SPOT_TO_COIN_MARGINED_FUTURES => new FuturesTransferType(3);
        public static FuturesTransferType COIN_MARGINED_FUTURES_TO_SPOT => new FuturesTransferType(4);

        public short Value { get; }

        public static implicit operator short(FuturesTransferType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}