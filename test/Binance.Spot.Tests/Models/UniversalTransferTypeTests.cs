namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class UniversalTransferTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            UniversalTransferType model = UniversalTransferType.MAIN_UMFUTURE;

            model.ToString().Should().Be(model.Value);
        }
    }
}