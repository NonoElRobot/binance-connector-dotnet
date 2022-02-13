namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class TransferDirectionTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            TransferDirection model = TransferDirection.TRANSFER_IN;

            model.ToString().Should().Be(model.Value.ToString());
        }
    }
}