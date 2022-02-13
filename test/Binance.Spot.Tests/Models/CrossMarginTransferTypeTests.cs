namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class CrossMarginTransferTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            CrossMarginTransferType model = CrossMarginTransferType.ROLL_IN;

            model.ToString().Should().Be(model.Value);
        }
    }
}