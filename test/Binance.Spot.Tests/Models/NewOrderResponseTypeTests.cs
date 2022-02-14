namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class NewOrderResponseTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            NewOrderResponseType model = NewOrderResponseType.ACK;

            model.ToString().Should().Be(model.Value);
        }
    }
}