namespace Binance.Spot.Models
{
    public readonly struct WithdrawStatus
    {
        private WithdrawStatus(string value)
        {
            this.Value = value;
        }

        public static WithdrawStatus EMAIL_SENT => new WithdrawStatus("EMAIL_SENT");
        public static WithdrawStatus CANCELLED => new WithdrawStatus("CANCELLED");
        public static WithdrawStatus AWAITING_APPROVAL => new WithdrawStatus("AWAITING_APPROVAL");
        public static WithdrawStatus REJECTED => new WithdrawStatus("REJECTED");
        public static WithdrawStatus PROCESSING => new WithdrawStatus("PROCESSING");
        public static WithdrawStatus FAILURE => new WithdrawStatus("FAILURE");

        public static WithdrawStatus COMPLETED => new WithdrawStatus("COMPLETED");

        public string Value { get; }

        public static implicit operator string(WithdrawStatus enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}