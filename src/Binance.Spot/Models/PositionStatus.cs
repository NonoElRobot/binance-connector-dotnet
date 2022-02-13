namespace Binance.Spot.Models
{
    public readonly struct PositionStatus
    {
        private PositionStatus(string value)
        {
            this.Value = value;
        }

        public static PositionStatus HOLDING => new PositionStatus("HOLDING");
        public static PositionStatus REDEEMED => new PositionStatus("REDEEMED");

        public string Value { get; }

        public static implicit operator string(PositionStatus enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}