namespace Binance.Spot.Models
{
    public readonly struct ProductStatus
    {
        private ProductStatus(string value)
        {
            this.Value = value;
        }

        public static ProductStatus ALL => new ProductStatus("ALL");
        public static ProductStatus SUBSCRIBABLE => new ProductStatus("SUBSCRIBABLE");
        public static ProductStatus UNSUBSCRIBABLE => new ProductStatus("UNSUBSCRIBABLE");

        public string Value { get; }

        public static implicit operator string(ProductStatus enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}