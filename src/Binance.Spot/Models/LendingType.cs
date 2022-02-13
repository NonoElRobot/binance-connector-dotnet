namespace Binance.Spot.Models
{
    public readonly struct LendingType
    {
        private LendingType(string value)
        {
            this.Value = value;
        }

        public static LendingType DAILY => new LendingType("DAILY");
        public static LendingType ACTIVITY => new LendingType("ACTIVITY");
        public static LendingType CUSTOMIZED_FIXED => new LendingType("CUSTOMIZED_FIXED");

        public string Value { get; }

        public static implicit operator string(LendingType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}