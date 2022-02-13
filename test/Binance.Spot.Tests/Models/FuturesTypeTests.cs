namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class FuturesTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            FuturesType model = FuturesType.USDT_MARGINED_FUTURES;

            model.ToString().Should().Be(model.Value.ToString());
        }
    }
}