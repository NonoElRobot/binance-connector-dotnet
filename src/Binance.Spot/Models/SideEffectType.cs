namespace Binance.Spot.Models
{
    public readonly struct SideEffectType
    {
        private SideEffectType(string value)
        {
            this.Value = value;
        }

        public static SideEffectType NO_SIDE_EFFECT => new SideEffectType("NO_SIDE_EFFECT");
        public static SideEffectType MARGIN_BUY => new SideEffectType("MARGIN_BUY");
        public static SideEffectType AUTO_REPAY => new SideEffectType("AUTO_REPAY");

        public string Value { get; }

        public static implicit operator string(SideEffectType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}