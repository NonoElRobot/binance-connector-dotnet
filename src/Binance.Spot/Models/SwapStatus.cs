namespace Binance.Spot.Models
{
    public readonly struct SwapStatus
    {
        private SwapStatus(short value)
        {
            this.Value = value;
        }

        public static SwapStatus PENDING_FOR_SWAP => new SwapStatus(0);
        public static SwapStatus SUCCESS => new SwapStatus(1);
        public static SwapStatus FAILED => new SwapStatus(2);

        public short Value { get; }

        public static implicit operator short(SwapStatus enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}