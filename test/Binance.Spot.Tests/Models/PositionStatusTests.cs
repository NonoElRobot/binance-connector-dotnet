namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class PositionStatusTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            PositionStatus model = PositionStatus.HOLDING;

            model.ToString().Should().Be(model.Value);
        }
    }
}