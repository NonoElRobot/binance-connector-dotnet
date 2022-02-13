namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class RedemptionTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            RedemptionType model = RedemptionType.FAST;

            model.ToString().Should().Be(model.Value);
        }
    }
}