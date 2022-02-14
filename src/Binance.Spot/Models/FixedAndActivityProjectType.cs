namespace Binance.Spot.Models
{
    public readonly struct FixedAndActivityProjectType
    {
        private FixedAndActivityProjectType(string value)
        {
            this.Value = value;
        }

        public static FixedAndActivityProjectType ACTIVITY => new FixedAndActivityProjectType("ACTIVITY");

        public static FixedAndActivityProjectType CUSTOMIZED_FIXED =>
            new FixedAndActivityProjectType("CUSTOMIZED_FIXED");

        public string Value { get; }

        public static implicit operator string(FixedAndActivityProjectType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}