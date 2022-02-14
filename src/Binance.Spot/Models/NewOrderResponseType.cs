namespace Binance.Spot.Models
{
    public readonly struct NewOrderResponseType
    {
        private NewOrderResponseType(string value)
        {
            this.Value = value;
        }

        public static NewOrderResponseType ACK => new NewOrderResponseType("ACK");
        public static NewOrderResponseType RESULT => new NewOrderResponseType("RESULT");
        public static NewOrderResponseType FULL => new NewOrderResponseType("FULL");

        public string Value { get; }

        public static implicit operator string(NewOrderResponseType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}