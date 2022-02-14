namespace Binance.Spot.Models
{
    public readonly struct ProductFeatured
    {
        private ProductFeatured(string value)
        {
            this.Value = value;
        }

        public static ProductFeatured ALL => new ProductFeatured("ALL");
        public static ProductFeatured TRUE => new ProductFeatured("TRUE");

        public string Value { get; }

        public static implicit operator string(ProductFeatured enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}