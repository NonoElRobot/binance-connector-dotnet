namespace Binance.Spot.Models
{
    public readonly struct MarginTransferType
    {
        private MarginTransferType(short value)
        {
            this.Value = value;
        }

        public static MarginTransferType SPOT_TO_MARGIN => new MarginTransferType(1);
        public static MarginTransferType MARGIN_TO_SPOT => new MarginTransferType(2);

        public short Value { get; }

        public static implicit operator short(MarginTransferType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}