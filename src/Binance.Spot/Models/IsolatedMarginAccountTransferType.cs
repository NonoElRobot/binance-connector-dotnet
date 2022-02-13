namespace Binance.Spot.Models
{
    public readonly struct IsolatedMarginAccountTransferType
    {
        private IsolatedMarginAccountTransferType(string value)
        {
            this.Value = value;
        }

        public static IsolatedMarginAccountTransferType SPOT => new IsolatedMarginAccountTransferType("SPOT");

        public static IsolatedMarginAccountTransferType ISOLATED_MARGIN =>
            new IsolatedMarginAccountTransferType("ISOLATED_MARGIN");

        public string Value { get; }

        public static implicit operator string(IsolatedMarginAccountTransferType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}