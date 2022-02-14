namespace Binance.Spot.Models
{
    public readonly struct LiquidityOperation
    {
        private LiquidityOperation(string value)
        {
            this.Value = value;
        }

        public static LiquidityOperation ADD => new LiquidityOperation("ADD");
        public static LiquidityOperation REMOVE => new LiquidityOperation("REMOVE");

        public string Value { get; }

        public static implicit operator string(LiquidityOperation enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}