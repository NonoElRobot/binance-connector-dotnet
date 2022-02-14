namespace Binance.Spot.Models
{
    public readonly struct CrossMarginTransferType
    {
        private CrossMarginTransferType(string value)
        {
            this.Value = value;
        }

        public static CrossMarginTransferType ROLL_IN => new CrossMarginTransferType("ROLL_IN");
        public static CrossMarginTransferType ROLL_OUT => new CrossMarginTransferType("ROLL_OUT");

        public string Value { get; }

        public static implicit operator string(CrossMarginTransferType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}