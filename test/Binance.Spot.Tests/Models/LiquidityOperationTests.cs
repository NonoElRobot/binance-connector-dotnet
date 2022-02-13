namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class LiquidityOperationTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            LiquidityOperation model = LiquidityOperation.ADD;

            model.ToString().Should().Be(model.Value);
        }
    }
}