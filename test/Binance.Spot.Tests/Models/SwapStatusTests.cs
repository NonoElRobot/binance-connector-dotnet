namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class SwapStatusTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            SwapStatus model = SwapStatus.PENDING_FOR_SWAP;

            model.ToString().Should().Be(model.Value.ToString());
        }
    }
}