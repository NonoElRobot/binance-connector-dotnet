namespace Binance.Spot.Models
{
    public readonly struct DepositStatus
    {
        private DepositStatus(short value)
        {
            this.Value = value;
        }

        public static DepositStatus PENDING => new DepositStatus(0);
        public static DepositStatus CREDITED_BUT_CANNOT_WITHDRAW => new DepositStatus(6);
        public static DepositStatus SUCCESS => new DepositStatus(1);

        public short Value { get; }

        public static implicit operator short(DepositStatus enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}