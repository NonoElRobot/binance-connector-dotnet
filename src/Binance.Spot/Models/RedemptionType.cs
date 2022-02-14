namespace Binance.Spot.Models
{
    public readonly struct RedemptionType
    {
        private RedemptionType(string value)
        {
            this.Value = value;
        }

        public static RedemptionType FAST => new RedemptionType("FAST");
        public static RedemptionType NORMAL => new RedemptionType("NORMAL");

        public string Value { get; }

        public static implicit operator string(RedemptionType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}