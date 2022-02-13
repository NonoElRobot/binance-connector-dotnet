namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class FuturesTransferTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            FuturesTransferType model = FuturesTransferType.SPOT_TO_USDT_MARGINED_FUTURES;

            model.ToString().Should().Be(model.Value.ToString());
        }
    }
}