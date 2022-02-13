namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class TimeInForceTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            TimeInForce model = TimeInForce.GTC;

            model.ToString().Should().Be(model.Value);
        }
    }
}