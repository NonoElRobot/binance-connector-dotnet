namespace Binance.Spot.Tests.Models
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spot.Models;

    public class FiatOrderTransactionTypeTests
    {
        [TestMethod]
        public void ToString_Matches_Value()
        {
            FiatOrderTransactionType model = FiatOrderTransactionType.DEPOSIT;

            model.ToString().Should().Be(model.Value.ToString());
        }
    }
}