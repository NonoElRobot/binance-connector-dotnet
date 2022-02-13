namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class LiquidityRemovalTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            LiquidityRemovalType model = LiquidityRemovalType.SINGLE;

            model.ToString().Should().Be(model.Value);
        }
    }
}