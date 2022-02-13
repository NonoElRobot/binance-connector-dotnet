namespace Binance.Spot.Models
{
    public readonly struct OrderType
    {
        private OrderType(string value)
        {
            this.Value = value;
        }

        public static OrderType LIMIT => new OrderType("LIMIT");
        public static OrderType MARKET => new OrderType("MARKET");
        public static OrderType STOP_LOSS => new OrderType("STOP_LOSS");
        public static OrderType STOP_LOSS_LIMIT => new OrderType("STOP_LOSS_LIMIT");
        public static OrderType TAKE_PROFIT => new OrderType("TAKE_PROFIT");
        public static OrderType TAKE_PROFIT_LIMIT => new OrderType("TAKE_PROFIT_LIMIT");
        public static OrderType LIMIT_MAKER => new OrderType("LIMIT_MAKER");

        public string Value { get; }

        public static implicit operator string(OrderType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}