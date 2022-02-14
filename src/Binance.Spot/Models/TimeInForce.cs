namespace Binance.Spot.Models
{
    public readonly struct TimeInForce
    {
        private TimeInForce(string value)
        {
            this.Value = value;
        }

        public static TimeInForce GTC => new TimeInForce("GTC");
        public static TimeInForce FOK => new TimeInForce("FOK");
        public static TimeInForce IOC => new TimeInForce("IOC");

        public string Value { get; }

        public static implicit operator string(TimeInForce enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}