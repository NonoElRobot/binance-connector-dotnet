namespace Binance.Spot.Models
{
    public readonly struct LiquidityRemovalType
    {
        private LiquidityRemovalType(string value)
        {
            this.Value = value;
        }

        public static LiquidityRemovalType SINGLE => new LiquidityRemovalType("SINGLE");
        public static LiquidityRemovalType COMBINATION => new LiquidityRemovalType("COMBINATION");

        public string Value { get; }

        public static implicit operator string(LiquidityRemovalType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}