namespace Binance.Spot.Models
{
    public readonly struct TransferDirection
    {
        private TransferDirection(short value)
        {
            this.Value = value;
        }

        public static TransferDirection TRANSFER_IN => new TransferDirection(1);
        public static TransferDirection TRANSFER_OUT => new TransferDirection(2);

        public short Value { get; }

        public static implicit operator short(TransferDirection enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}