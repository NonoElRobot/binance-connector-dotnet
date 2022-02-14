namespace Binance.Spot.Models
{
    public readonly struct UniversalTransferType
    {
        private UniversalTransferType(string value)
        {
            this.Value = value;
        }

        public static UniversalTransferType MAIN_UMFUTURE => new UniversalTransferType("MAIN_UMFUTURE");
        public static UniversalTransferType MAIN_CMFUTURE => new UniversalTransferType("MAIN_CMFUTURE");
        public static UniversalTransferType MAIN_MARGIN => new UniversalTransferType("MAIN_MARGIN");
        public static UniversalTransferType UMFUTURE_MAIN => new UniversalTransferType("UMFUTURE_MAIN");
        public static UniversalTransferType UMFUTURE_MARGIN => new UniversalTransferType("UMFUTURE_MARGIN");
        public static UniversalTransferType CMFUTURE_MAIN => new UniversalTransferType("CMFUTURE_MAIN");
        public static UniversalTransferType CMFUTURE_MARGIN => new UniversalTransferType("CMFUTURE_MARGIN");
        public static UniversalTransferType MARGIN_MAIN => new UniversalTransferType("MARGIN_MAIN");
        public static UniversalTransferType MARGIN_UMFUTURE => new UniversalTransferType("MARGIN_UMFUTURE");
        public static UniversalTransferType MARGIN_CMFUTURE => new UniversalTransferType("MARGIN_CMFUTURE");
        public static UniversalTransferType ISOLATEDMARGIN_MARGIN => new UniversalTransferType("ISOLATEDMARGIN_MARGIN");
        public static UniversalTransferType MARGIN_ISOLATEDMARGIN => new UniversalTransferType("MARGIN_ISOLATEDMARGIN");

        public static UniversalTransferType ISOLATEDMARGIN_ISOLATEDMARGIN =>
            new UniversalTransferType("ISOLATEDMARGIN_ISOLATEDMARGIN");

        public static UniversalTransferType MAIN_FUNDING => new UniversalTransferType("MAIN_FUNDING");
        public static UniversalTransferType FUNDING_MAIN => new UniversalTransferType("FUNDING_MAIN");
        public static UniversalTransferType FUNDING_UMFUTURE => new UniversalTransferType("FUNDING_UMFUTURE");
        public static UniversalTransferType UMFUTURE_FUNDING => new UniversalTransferType("UMFUTURE_FUNDING");
        public static UniversalTransferType MARGIN_FUNDING => new UniversalTransferType("MARGIN_FUNDING");
        public static UniversalTransferType FUNDING_MARGIN => new UniversalTransferType("FUNDING_MARGIN");
        public static UniversalTransferType FUNDING_CMFUTURE => new UniversalTransferType("FUNDING_CMFUTURE");
        public static UniversalTransferType CMFUTURE_FUNDING => new UniversalTransferType("CMFUTURE_FUNDING");

        public string Value { get; }

        public static implicit operator string(UniversalTransferType enm)
        {
            return enm.Value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}