namespace Binance.Spot.Models
{
    public readonly struct LoanDirection
    {
        private LoanDirection(string value)
        {
            this.Value = value;
        }

        public static LoanDirection ADDITIONAL => new LoanDirection("ADDITIONAL");
        public static LoanDirection REDUCED => new LoanDirection("REDUCED");

        public string Value { get; }

        public static implicit operator string(LoanDirection enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}