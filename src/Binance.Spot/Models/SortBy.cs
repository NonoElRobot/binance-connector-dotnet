namespace Binance.Spot.Models
{
    public readonly struct SortBy
    {
        private SortBy(string value)
        {
            this.Value = value;
        }

        public static SortBy START_TIME => new SortBy("START_TIME");
        public static SortBy LOT_SIZE => new SortBy("LOT_SIZE");
        public static SortBy INTEREST_RATE => new SortBy("INTEREST_RATE");
        public static SortBy DURATION => new SortBy("DURATION");

        public string Value { get; }

        public static implicit operator string(SortBy enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}