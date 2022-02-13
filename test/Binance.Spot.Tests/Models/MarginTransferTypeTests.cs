namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class MarginTransferTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            MarginTransferType model = MarginTransferType.SPOT_TO_MARGIN;

            model.ToString().Should().Be(model.Value.ToString());
        }
    }
}