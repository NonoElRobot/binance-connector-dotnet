namespace Binance.Spot.Models
{
    public readonly struct Side
    {
        private Side(string value)
        {
            this.Value = value;
        }

        public static Side BUY => new Side("BUY");
        public static Side SELL => new Side("SELL");

        public string Value { get; }

        public static implicit operator string(Side enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}