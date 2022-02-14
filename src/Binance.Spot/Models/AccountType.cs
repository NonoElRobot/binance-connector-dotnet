namespace Binance.Spot.Models
{
    public readonly struct AccountType
    {
        private AccountType(string value)
        {
            this.Value = value;
        }

        public static AccountType SPOT => new AccountType("SPOT");
        public static AccountType MARGIN => new AccountType("MARGIN");
        public static AccountType FUTURES => new AccountType("FUTURES");

        public string Value { get; }

        public static implicit operator string(AccountType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}