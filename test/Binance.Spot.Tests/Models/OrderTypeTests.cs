namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class OrderTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            OrderType model = OrderType.LIMIT;

            model.ToString().Should().Be(model.Value);
        }
    }
}