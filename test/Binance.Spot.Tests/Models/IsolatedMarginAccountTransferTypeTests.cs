namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class IsolatedMarginAccountTransferTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            IsolatedMarginAccountTransferType model = IsolatedMarginAccountTransferType.SPOT;

            model.ToString().Should().Be(model.Value);
        }
    }
}